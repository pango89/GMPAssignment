using System;
using System.Collections.Generic;
using System.Text;

namespace GMPAssignment.Models
{
    public class User
    {
        private static int autoIncrementId = 1;
        public User(string name, string address, string birthDate)
        {
            this.Id = autoIncrementId++;
            this.Name = name;
            this.Address = address;
            this.BirthDate = birthDate;
            this.IsAdmin = false;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string BirthDate { get; private set; }
        public bool IsAdmin { get; private set; }

        public void PromoteToAdmin()
        {
            this.IsAdmin = true;
        }
    }
}
