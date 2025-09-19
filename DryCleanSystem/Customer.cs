using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Customer : User
    {
        public decimal WalletBalance { get; private set; }
        public Customer(string userName, string password, string phoneNumber, string address)
        : base(userName, password, phoneNumber, address)
        {
            WalletBalance = 0; // Starts with zero balance
        }
        public override bool Login(string userName, string password)
        {
            return UserName == userName && Password == password;
        }
        public void RechargeWallet(decimal amount)
        {
            WalletBalance += amount;
            Console.WriteLine($"Wallet recharged. New balance: {WalletBalance:C}");
        }
        public Order PlaceOrder(List<Service> services, int orderId)
        {
            Order newOrder = new Order(orderId, this, services);
            if (WalletBalance >= newOrder.TotalAmount)
            {
                WalletBalance -= newOrder.TotalAmount;
                Console.WriteLine($"Order {newOrder.OrderId} placed. Remaining balance:{ WalletBalance: C}");
            return newOrder;
            }
            else
            {
                Console.WriteLine("Insufficient funds to place the order.");
                return null;
            }
        }
    }
}
