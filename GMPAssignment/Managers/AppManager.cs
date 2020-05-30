using GMPAssignment.Interfaces;
using GMPAssignment.Models;
using System;
using System.Collections.Generic;

namespace GMPAssignment.Managers
{
    public class AppManager : IAppManager
    {
        public AppManager(ILoginManager loginManager, IProductManager productManager, ICartManager cartManager)
        {
            this.LoginManager = loginManager;
            this.ProductManager = productManager;
            this.CartManager = cartManager;
        }

        public ILoginManager LoginManager { get; private set; }
        public IProductManager ProductManager { get; private set; }
        public ICartManager CartManager { get; private set; }

        /// <summary>
        /// Create Admin User
        /// </summary>
        /// <returns></returns>
        public int CreateAdminUser()
        {
            return this.SignUp("Admin", "BLR", "01/01/2000", true);
        }
        
        /// <summary>
        /// Method for signing up
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="dob"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public int SignUp(string name, string address, string dob, bool isAdmin = false)
        {
            User user = new User(name, address, dob);
            if (isAdmin)
                user.PromoteToAdmin();

            this.LoginManager.SignUp(user);

            // Create a CART for User
            this.CartManager.AddCartForUser(user.Id);
            return user.Id;
        }

        /// <summary>
        /// Method for login
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Login(int userId)
        {
            return this.LoginManager.Login(userId);
        }

        /// <summary>
        /// Method for logout
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Logout(int userId)
        {
            return this.LoginManager.Logout(userId);
        }

        /// <summary>
        /// Method for showing cart for a user
        /// </summary>
        /// <param name="userId"></param>
        public void ShowCart(int userId)
        {
            Console.WriteLine("{0}   {1}   {2}   {3}   {4}   {5}", "Product Id", "Name", "Description", "Unit Price", "Quantity", "Total");
            this.CartManager.ShowCart(userId);
        }

        /// <summary>
        /// Method for showing products in system
        /// </summary>
        public void ShowProducts()
        {
            Console.WriteLine("{0}   {1}   {2}   {3}", "Product Id", "Name", "Description", "Price");
            this.ProductManager.ShowProducts();
        }

        /// <summary>
        /// Method for adding a product in the system
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int AddProduct(string name, string description, double price)
        {
            Product product = new Product(name, description, price);
            this.ProductManager.AddProduct(product, 0);
            return product.Id;
        }

        /// <summary>
        /// Method for updating product details
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateProduct(int productId, string name, string description, double price)
        {
            Product product = this.ProductManager.GetProduct(productId);
            if (product == null)
                return false;

            product.UpdateProduct(name, description, price);
            // Product as an object is used so no Need to reflect changes manually to Carts. Should Automatically happen

            return true;
        }

        /// <summary>
        /// Method for deleting a product from system
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            Product product = this.ProductManager.GetProduct(productId);
            if (product == null)
                return false;

            // Check this product in Carts For All Users and Remove
            List<User> users = this.LoginManager.GetAllUsers();
            foreach (User user in users)
                this.CartManager.RemoveProductFromCart(user.Id, product.Id);

            this.ProductManager.DeleteProduct(product);
            return true;
        }

        /// <summary>
        /// Method to add a product to user cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool AddProductToCart(int userId, int productId, int quantity)
        {
            Product product = this.ProductManager.GetProduct(productId);
            if (product != null)
            {
                this.CartManager.AddProductToCart(userId, product, quantity);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Method to chechout
        /// </summary>
        /// <param name="userId"></param>
        public void Checkout(int userId)
        {
            this.CartManager.Checkout(userId);
            Console.WriteLine("Please Pay the above amount on Delivery!");
        }
    }
}
