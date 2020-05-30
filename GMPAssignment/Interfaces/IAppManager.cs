namespace GMPAssignment.Interfaces
{
    public interface IAppManager
    {
        int CreateAdminUser();
        int SignUp(string name, string address, string dob, bool isAdmin = false);
        bool Login(int userId);
        bool Logout(int userId);
        void ShowCart(int userId);
        void ShowProducts();
        int AddProduct(string name, string description, double price);
        bool UpdateProduct(int productId, string name, string description, double price);
        bool DeleteProduct(int productId);
        bool AddProductToCart(int userId, int productId, int quantity);
        void Checkout(int userId);
    }
}
