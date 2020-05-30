using GMPAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMPAssignment.Interfaces
{
    public interface IProductManager
    {
        void AddProduct(Product product, int quantity);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        void ShowProducts();

        Product GetProduct(int productId);
    }
}
