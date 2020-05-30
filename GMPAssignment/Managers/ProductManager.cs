using GMPAssignment.Interfaces;
using GMPAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GMPAssignment.Managers
{
    public class ProductManager : IProductManager
    {
        public ProductManager()
        {
            this.Products = new List<Product>();
            this.ProductInventory = new Dictionary<int, int>();
        }

        public List<Product> Products { get; private set; }

        public Dictionary<int, int> ProductInventory { get; private set; }

        public void AddProduct(Product product, int quantity)
        {
            if (!this.ProductInventory.ContainsKey(product.Id))
            {
                this.Products.Add(product);
                this.ProductInventory[product.Id] = 0;
            }

            this.ProductInventory[product.Id] += quantity;
        }

        public void DeleteProduct(Product product)
        {
            if (this.ProductInventory.ContainsKey(product.Id))
            {
                this.Products.Remove(product);
                this.ProductInventory.Remove(product.Id);
            }
        }

        public void UpdateProduct(Product product)
        {
            if (this.ProductInventory.ContainsKey(product.Id))
            {
                this.Products.RemoveAll(x => x.Id == product.Id);
                this.Products.Add(product);
            }
        }

        public void ShowProducts()
        {
            if(this.Products.Count == 0)
                Console.WriteLine("No Products to Show!");

            foreach (Product product in this.Products)
                Console.WriteLine(product.ToString());
        }

        public Product GetProduct(int productId)
        {
            if (this.ProductInventory.ContainsKey(productId))
                return this.Products.First(x => x.Id == productId);

            return null;
        }
    }
}
