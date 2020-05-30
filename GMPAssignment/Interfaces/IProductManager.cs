using GMPAssignment.Models;

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
