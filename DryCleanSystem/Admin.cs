using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Admin : User
    {
        private static int counter = 1;
        public Admin() {
            id = ++counter;
        }
        public Admin(int id, string userName, string password, string phone, string address, string role) : base(id, userName, password, phone, address, role)
        {
            id = ++counter;
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

        public void deleteService(List<Service> services, int serviceId) {
            Console.WriteLine("Enter service you want to delete:");
            serviceId = int.Parse(Console.ReadLine());
            for (int i = 0; i < services.Count; i++) {
                if (services[i].id != serviceId)
                {
                    Console.WriteLine($"Service with ID {serviceId} not found.");
                }
                else { 
                   services.Remove(services[i]);
                    Console.WriteLine($"Service {services[i].name} deleted successfully!");
                }
            }
 
        }
        public void assignDriver(Order order, Driver driver) {
            order.assignedDriver = driver;
            Console.WriteLine($"Driver {driver.name} assigned to Order {order.id}");
        }
    }
}
