using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DryCleanSystem
{
    public abstract class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }

        public bool loginStatus = false;

        public User() { }
        public User(int id, string name, string password, string phone, string address, string role) {
            this.id = id;
            this.name = name;
            this.password = password;
            this.phone = phone;
            this.address = address;
            this.role = role;
        }

        public virtual void register() {
            Console.Write("Enter User Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter password");
            password = Console.ReadLine();
            Console.WriteLine("Enter ConfirmPassword");
            string confirmPassword = Console.ReadLine();
            while (confirmPassword != password)
            {
                Console.WriteLine("confirm password doesn't match password, try again");
                confirmPassword = Console.ReadLine();
            }
            Console.WriteLine("Enter phone number:");
            phone = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            address = Console.ReadLine();
        }
        public bool login(string name, string password) {

            if(this.name == name && this.password == password)
    {
                Console.WriteLine("logged in successfully.");
                loginStatus = true;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password!");
                loginStatus=false;
                return false;
            }

        }
        public void logout() {
            Console.WriteLine($"{name} logged out.");
        }
    }
}
