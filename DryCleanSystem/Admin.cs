using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Admin : User, IUser
    {
        private static int counter = 1;
        public Admin() {
            id = counter++;
        }
        public Admin(int id, string userName, string password, string phone, string address, string role) : base(id, userName, password, phone, address, role)
        {
            id = counter + 1;
        }
        public override void register()
        {
            base.register();
                role ="Admin";
        }

        public void addService(List<Service> services, Service newService) {
            services.Add(newService);
            Console.WriteLine($"Service {newService.name} added successfully!");
        }

        public void deleteService(List<Service> services, Service service) {

            services.Remove(service);
 
        }
        public void assignDriver(Order order, Driver driver) {
            if (order == null)
            {
                Console.WriteLine("Order not found!");
                return;
            }

            if (driver == null)
            {
                Console.WriteLine("Driver not found!");
                return;
            }

            order.assignedDriver = driver;
            order.status = "assigned";

            Console.WriteLine($"Driver {driver.name} assigned to Order {order.id} successfully.");
        }

        public void showUserType()
        {
            Console.WriteLine("I'm an Admin");
        }
    }
}
