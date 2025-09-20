using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Driver : User
    {
        private static int counter = 1;
        List<Order> allOrders;
        public Driver() {
            id = ++counter;
        }
        public Driver(int id, string userName, string password, string phone, string address, string role) : base(id, userName, password, phone, address, role)
        {
            id = counter++;
        }
        public override void register()
        {
            base.register();
            role = "Driver";
        }

        public void updateOrderStatus(Order order, string status) {
            order.updateStatus(status);
            Console.WriteLine($"Order {order.id} status updated to {status}");
        }

        public void viewAssignedOrder() {
            foreach (var order in allOrders.Where(o => o.assignedDriver == this))
                Console.WriteLine($"Order{allOrders.Count} {order.id} - {order.services} - {order.customer.name} - {order.totalCost}");
        }
    }
    }
