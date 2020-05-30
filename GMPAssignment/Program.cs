using GMPAssignment.Interfaces;
using GMPAssignment.Managers;
using System;

namespace GMPAssignment
{
    class Program
    {
        public static int UserId = -1;

        /// <summary>
        /// Main Entry Code
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            ILoginManager loginManager = new LoginManager();
            IProductManager productManager = new ProductManager();
            ICartManager cartManager = new CartManager();
            IAppManager manager = new AppManager(loginManager, productManager, cartManager);

            // Create Admin User
            int adminUserId = manager.CreateAdminUser();
            Console.WriteLine("Admin User Id is {0}", adminUserId);

            bool shouldContinue = true;
            while (shouldContinue)
            {
                if (UserId == -1)
                    shouldContinue = PreLogin(manager);
                else
                    shouldContinue = PostLogin(manager, UserId, UserId == adminUserId);
            }
        }

        /// <summary>
        /// Menu to be shown before login
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        private static bool PreLogin(IAppManager manager)
        {
            while (true)
            {
                ShowMenuPreLogin();
                Console.Write("Enter Your Choice(0-3): ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 0)
                    return false;

                int userId;
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter User Details -");
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Address: ");
                        string address = Console.ReadLine();

                        Console.Write("DOB: ");
                        string dob = Console.ReadLine();

                        int generatedUserId = manager.SignUp(name, address, dob);
                        Console.WriteLine("User Signed Up successfully with user id {0}", generatedUserId);
                        break;
                    case 2:
                        Console.Write("Enter User Id: ");
                        userId = Convert.ToInt32(Console.ReadLine());
                        bool isSuccess = manager.Login(userId);
                        if (isSuccess)
                        {
                            Console.WriteLine("User with user id {0} successfully signed in.", userId);
                            UserId = userId;
                        }
                        else
                            Console.WriteLine("Invalid User Id");
                        break;
                    case 3:
                        manager.ShowProducts();
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }

                return true;
            }
        }

        /// <summary>
        /// Operations post login
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="userId"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        private static bool PostLogin(IAppManager manager, int userId, bool isAdmin)
        {
            while (true)
            {
                ShowMenuPostLogin(userId);
                Console.Write("Enter Your Choice(0-8): ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 0)
                    return false;

                switch (option)
                {
                    case 1:
                        bool isSuccess = manager.Logout(userId);
                        if (isSuccess)
                        {
                            Console.WriteLine("User {0} Signed out successfully.", userId);
                            UserId = -1;
                        }
                        else
                            Console.WriteLine("Invalid User Id");
                        break;
                    case 2:
                        manager.ShowCart(userId);
                        break;
                    case 3:
                        manager.ShowProducts();
                        break;
                    case 4:
                        Console.WriteLine("Enter Product Details For Adding to Cart -");
                        Console.Write("ProductId: ");
                        int productId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        bool success = manager.AddProductToCart(userId, productId, quantity);
                        if (success)
                        {
                            Console.WriteLine("Product Added to Cart Successfully.");
                            Console.WriteLine();
                            manager.ShowCart(userId);
                        }
                        else
                            Console.WriteLine("Invalid Product!");
                        break;
                    case 5:
                        Console.WriteLine();
                        manager.Checkout(userId);
                        Console.WriteLine();
                        break;
                    case 6:
                        if (!isAdmin)
                        {
                            Console.WriteLine("User not authorized to do this operation!");
                            break;
                        }

                        Console.WriteLine("Enter Product Details -");
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Description: ");
                        string description = Console.ReadLine();

                        Console.Write("Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        int generatedProductId = manager.AddProduct(name, description, price);
                        Console.WriteLine("Product added successfully with product id {0}", generatedProductId);
                        Console.WriteLine();
                        manager.ShowProducts();
                        break;
                    case 7:
                        if (!isAdmin)
                        {
                            Console.WriteLine("User not authorized to do this operation!");
                            break;
                        }

                        Console.WriteLine("Enter Product Id to Modify: ");
                        productId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Product Details -");
                        Console.Write("Name: ");
                        name = Console.ReadLine();

                        Console.Write("Description: ");
                        description = Console.ReadLine();

                        Console.Write("Price: ");
                        price = Convert.ToDouble(Console.ReadLine());

                        success = manager.UpdateProduct(productId, name, description, price);
                        if (success)
                        {
                            Console.WriteLine("Successfully upadted Product with product id {0}", productId);
                            manager.ShowProducts();
                        }
                        else
                            Console.WriteLine("Failed To Update Product!");
                        break;
                    case 8:
                        if (!isAdmin)
                        {
                            Console.WriteLine("User not authorized to do this operation!");
                            break;
                        }

                        Console.WriteLine("Enter Product Id to Delete: ");
                        productId = Convert.ToInt32(Console.ReadLine());

                        success = manager.DeleteProduct(productId);
                        if (success)
                        {
                            Console.WriteLine("Successfully deleted Product with product id {0}", productId);
                            manager.ShowProducts();
                        }
                        else
                            Console.WriteLine("Failed To Delete Product!");
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }

                return true;
            }
        }

        /// <summary>
        /// Menu to be shown before login
        /// </summary>
        private static void ShowMenuPreLogin()
        {
            Console.WriteLine();
            Console.WriteLine("########## MENU ##########");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Sign Up New User");
            Console.WriteLine("2. Sign In User");
            Console.WriteLine("3. Display Products");
            Console.WriteLine();
        }

        /// <summary>
        /// Menu to be show post login
        /// </summary>
        /// <param name="userId"></param>
        private static void ShowMenuPostLogin(int userId)
        {
            Console.WriteLine();
            Console.WriteLine("Logged In User ID = {0}", userId);
            Console.WriteLine("########## MENU ##########");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Sign Out");
            Console.WriteLine("2. Display Cart");
            Console.WriteLine("3. Display Products");
            Console.WriteLine("4. Add Product to Cart");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Add Product(Admin User Only)");
            Console.WriteLine("7. Modify Product(Admin User Only)");
            Console.WriteLine("8. Delete Product(Admin User Only)");
            Console.WriteLine();
        }
    }
}
