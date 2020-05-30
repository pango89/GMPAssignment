using GMPAssignment.Models;
using System.Collections.Generic;

namespace GMPAssignment.Interfaces
{
    public interface ILoginManager
    {
        void SignUp(User user);
        bool Login(int id);
        bool Logout(int id);
        bool IsUserLoggedIn(int id);
        List<User> GetAllUsers();
    }
}
