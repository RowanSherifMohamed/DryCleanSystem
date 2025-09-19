namespace DryCleanSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("--- Dry Cleaning System Simulation ---");
            // 1. Create System Users and Services
            var admin = new Admin("admin1", "adminpass");
            var customer = new Customer("Rowan", "rowanpass", "0123456789", "123 Main St");
            var driver = new Driver("Kareem", "driverpass");
            var dryCleaning = new Service(1, "Dry Cleaning", 15.50m);
            var washAndIron = new Service(2, "Wash & Ironing", 10.00m);
            // Admin manages services
            admin.AddService(dryCleaning);
            admin.AddService(washAndIron);
            Console.WriteLine("\n--- Customer Actions ---");
            // 2. Customer Registration and Wallet Recharge
            // In a real app, login would be a separate step
            if (customer.Login("Rowan", "rowanpass"))
            {
                Console.WriteLine($"Customer '{customer.UserName}' logged in successfully.");
                customer.RechargeWallet(50.00m);
            }
            // 3. Customer Places an Order
            var selectedServices = new List<Service> { dryCleaning, washAndIron, washAndIron };
            Order customerOrder = customer.PlaceOrder(selectedServices, 101);
            if (customerOrder != null)
            {
                Console.WriteLine($"\n--- Admin Actions ---");
                // 4. Admin Assigns a Driver
                admin.AssignDriverToOrder(customerOrder, driver);
                Console.WriteLine($"\n--- Driver Actions ---");
                // 5. Driver Updates Order Status
                Console.WriteLine($"Order {customerOrder.OrderId} current status: {customerOrder.Status}");
                driver.UpdateOrderStatus(customerOrder, "Picked Up");
                driver.UpdateOrderStatus(customerOrder, "In Progress");
                driver.UpdateOrderStatus(customerOrder, "Delivered");
                Console.WriteLine($"\nFinal Order Status: {customerOrder.Status}");
            }
        }
    }
}
