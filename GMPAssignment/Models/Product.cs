using System;
using System.Collections.Generic;
using System.Text;

namespace GMPAssignment.Models
{
    public class Product
    {
        private static int autoIncrementId = 1;

        public Product(string name, string description, double price)
        {
            this.Id = autoIncrementId++;
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public void UpdateProduct(string name, string description, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public override string ToString()
        {
            return this.Id + "     " + this.Name + "     " + this.Description + "     " + "INR " + this.Price;
        }
    }
}
