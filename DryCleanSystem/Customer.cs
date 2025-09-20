using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DryCleanSystem
{
    public class Customer : User
    {
        private static int counter = 1;
        public double walletBalance { get; set; }
        public List<Order> orders { get; set; }
        public Customer() {
            id = ++counter;
        }
        public Customer(int id, string userName, string password, string phone, string address, string role, double walletBalance) 
            : base(id, userName, password, phone, address, role)
        {
            id = ++counter;
            this.walletBalance = walletBalance;
        }
        public override void register()
        {
            base.register();
            role = "Customer";
            Console.WriteLine("Enter your Wallet Balance:");
            walletBalance = double.Parse(Console.ReadLine());
        }
            
        public void addToWallet(double amount) {
           walletBalance = walletBalance + amount;
        }

        public void createOrder(List<Service> orderServices) { 
            Order order = new Order() {customer = this, services = orderServices};
            orders.Add(order);
        }

        public void orderPayment(Order order) {
            if (walletBalance >= order.totalCost)
            {
                walletBalance -= order.totalCost;
                Console.WriteLine($"Order {order.id} paid successfully. Remaining balance: {walletBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance! Please recharge your wallet.");
            }
            } 

        public void viewOrder() {
            foreach (Order order in orders) {
                Console.WriteLine($"Order id: {order.id}");
                Console.WriteLine($"driver name: {order.assignedDriver.name}");
                Console.WriteLine($"Order cost: {order.totalCost}");
                Console.WriteLine($"Order status: {order.status}");
            }
        }
    }
}
