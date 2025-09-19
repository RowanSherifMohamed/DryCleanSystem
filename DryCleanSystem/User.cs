using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public abstract class User
    {
        // abstract class has 3 childs ( s)
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }

        public User(int id, string userName, string password, string phone, string address, string role) {
            this.id = id;
            this.userName = userName;
            this.password = password;
            this.phone = phone;
            this.address = address;
            this.role = role;
        }

        abstract public void register(string userName, string password, string confirmPassword, string phone, string address, string role);
        abstract public bool login(string userName, string password);
        abstract public void logout();
    }
}
