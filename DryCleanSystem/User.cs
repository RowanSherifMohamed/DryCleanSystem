using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    using System;
    using System.Collections.Generic;

    public abstract class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public abstract bool Login(string userName, string password);

        // Common constructor for all user types
        public User(string userName, string password, string phoneNumber = null, string address = null)
        {
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
