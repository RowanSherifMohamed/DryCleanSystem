using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Admin : User
    {
        private List<Service> availableServices;
        private List<Order> pendingOrders;

        public Admin(string userName, string password)
            : base(userName, password)
        {
            availableServices = new List<Service>();
            pendingOrders = new List<Order>();
        }

        public override bool Login(string userName, string password)
        {
            return UserName == userName && Password == password;
        }

        public void AddService(Service service)
        {
            availableServices.Add(service);
            Console.WriteLine($"Service '{service.Name}' added.");
        }

        public void AssignDriverToOrder(Order order, Driver driver)
        {
            if (order.Status == "Placed")
            {
                order.AssignDriver(driver);
                Console.WriteLine($"Driver '{driver.UserName}' assigned to order {order.OrderId}.");
            }
            else
            {
                Console.WriteLine("Cannot assign a driver to an order that is not in 'Placed' status.");
            }
        }
    }
}
