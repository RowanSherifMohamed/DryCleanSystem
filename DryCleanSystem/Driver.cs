using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Driver : User
    {
        public Driver(string userName, string password)
        : base(userName, password)
        {
        }
        public override bool Login(string userName, string password)
        {
            return UserName == userName && Password == password;
        }
        public void UpdateOrderStatus(Order order, string newStatus)
        {
            order.UpdateStatus(newStatus);
            Console.WriteLine($"Order {order.OrderId} status updated to: {newStatus}");
        }
    }
}
