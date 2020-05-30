using GMPAssignment.Models;

namespace GMPAssignment.Interfaces
{
    public interface ICartManager
    {
        void AddCartForUser(int userId);
        void AddProductToCart(int userId, Product product, int quantity);
        void Checkout(int userId);
        void ClearCart(int userId);
        void ShowCart(int userId);
        void RemoveProductFromCart(int userId, int productId);
    }
}
