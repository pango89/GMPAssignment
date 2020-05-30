using GMPAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
