using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Driver : User, IUser
    {
        private static int counter = 1;
        public Driver()
        {
            id = counter + 1;
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

        public void showUserType()
        {
            Console.WriteLine( "I'm a Driver");
        }

        public void updateOrderStatus(List<Order>orders,int orderId, string status)
        {
            Order orderToUpdate = null;

            foreach (var o in orders)
            {
                if (o.id == orderId && o.assignedDriver != null && o.assignedDriver.id == this.id)
                {
                    orderToUpdate = o;
                    break; 
                }
            }

            if (orderToUpdate == null)
            {
                Console.WriteLine($"Order with ID {orderId} not found or not assigned to you.");
                return;
            }

            orderToUpdate.updateStatus(status);
            Console.WriteLine($"Order {orderToUpdate.id} status updated to {status}");
        }

        public List<Order> viewAssignedOrder(List<Order> orders)
        {
            List<Order> myOrders = new List<Order>();

            foreach (var order in orders)
            {
                if (order.assignedDriver != null && order.assignedDriver.id == this.id)
                {
                    myOrders.Add(order);
                }
            }
            return myOrders;
        }
    }
    }
