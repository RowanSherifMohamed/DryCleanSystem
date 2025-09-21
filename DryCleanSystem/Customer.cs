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
    public class Customer : User, IUser
    {
        private static int counter = 1;
        public double walletBalance { get; set; }
        public List<Order> orders { get; set; } = new List<Order>();
        public Customer() {
            id = counter + 1;
            orders = new List<Order>();
        }
        public Customer(int id, string userName, string password, string phone, string address, string role, double walletBalance) 
            : base(id, userName, password, phone, address, role)
        {
            id = ++counter;
            this.walletBalance = walletBalance;
            orders = new List<Order>();
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
            Console.WriteLine($"{amount} pounds added successfully, your wallet balance = {walletBalance}");
        }

        public Order createOrder(List<Service> orderServices) {
            if (orders == null)
            {
                orders = new List<Order>();
            }

            Order order = new Order
            {
                status = "pending",
                services = orderServices
            };

            order.calculateTotalCost();
            orders.Add(order);
            return order;
        }

        public void orderPayment(Order order)
        {
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
                Console.WriteLine("===================================");
            }
        }

        public void showUserType()
        {
            Console.WriteLine("I'm a customer");
        }
    }
}
