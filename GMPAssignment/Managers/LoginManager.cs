using GMPAssignment.Interfaces;
using GMPAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMPAssignment.Managers
{
    public class LoginManager : ILoginManager
    {
        public List<User> Users { get; private set; }

        // User Id and User LoggedIn or not
        public Dictionary<int, bool> UsersStatus { get; set; }

        public LoginManager()
        {
            this.Users = new List<User>();
            this.UsersStatus = new Dictionary<int, bool>();
        }

        public bool Login(int userId)
        {
            if (this.UsersStatus.ContainsKey(userId))
            {
                this.UsersStatus[userId] = true;
                return true;
            }

            return false;
        }

        public bool Logout(int userId)
        {
            if (this.UsersStatus.ContainsKey(userId) && this.UsersStatus[userId])
            {
                this.UsersStatus[userId] = false;
                return true;
            }

            return false;
        }

        public void SignUp(User user)
        {
            if (!this.UsersStatus.ContainsKey(user.Id))
            {
                this.Users.Add(user);
                this.UsersStatus.Add(user.Id, false);
            }
        }

        public bool IsUserLoggedIn(int userId)
        {
            return this.UsersStatus.ContainsKey(userId) && this.UsersStatus[userId];
            
        }

        public List<User> GetAllUsers()
        {
            return this.Users;
        }
    }
}
