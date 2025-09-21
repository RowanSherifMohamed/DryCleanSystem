using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Order
    {
        private static int counter = 1;
        public int id { get; set; }
        public string status { get; set; }
        public double totalCost { get; set; }

        //public Customer customer { get; set; }

        public Driver assignedDriver { get; set; }
        public List<Service> services { get; set; }

        public Order() {
            id = counter + 1;
        }
        public void calculateTotalCost() {
            totalCost = 0;
            foreach (var service in services) {
                totalCost += service.price;
            }
            Console.WriteLine($"Total cost for Order {id} = {totalCost}");
        }

        public void updateStatus(string newStatus) {
            status = newStatus;
        }
    }
}
