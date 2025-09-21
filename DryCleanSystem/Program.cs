using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace DryCleanSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string customersFile = "D:\\DEPI (full stack .net web development)\\oop_project\\dry_clean_system\\DryCleanSystem\\DryCleanSystem\\customers.json";
            string adminsFile = "D:\\DEPI (full stack .net web development)\\oop_project\\dry_clean_system\\DryCleanSystem\\DryCleanSystem\\admins.json";
            string driversFile = "D:\\DEPI (full stack .net web development)\\oop_project\\dry_clean_system\\DryCleanSystem\\DryCleanSystem\\drivers.json";
            string servicesFile = "D:\\DEPI (full stack .net web development)\\oop_project\\dry_clean_system\\DryCleanSystem\\DryCleanSystem\\services.json";
            string ordersFile = "D:\\DEPI (full stack .net web development)\\oop_project\\dry_clean_system\\DryCleanSystem\\DryCleanSystem\\orders.json";


            Customer customer = new Customer();
            Driver driver = new Driver();
            Admin admin = new Admin();

            var customers = JsonDataManager<Customer>.Load(customersFile);
            var admins = JsonDataManager<Admin>.Load(adminsFile);
            var drivers = JsonDataManager<Driver>.Load(driversFile);
            var services = JsonDataManager<Service>.Load(servicesFile);
            var orders = JsonDataManager<Order>.Load(ordersFile);

            IUser customerUser = new Customer();
            customerUser.showUserType();
                Console.WriteLine("\n------- Dry Clean System -------");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Select Role: 1-Customer, 2-Admin, 3-Driver");
                string roleChoice = Console.ReadLine();
                if (roleChoice == "1")
                {
                    customer.register();
                    customers.Add(customer);
                    JsonDataManager<Customer>.Save(customersFile, customers);

                }
                else if (roleChoice == "2")
                {
                    admin.register();
                    admins.Add(admin);
                    JsonDataManager<Admin>.Save(adminsFile, admins);
                    Console.WriteLine("User registered successfully");
                }
                else if (roleChoice == "3")
                {
                    driver.register();
                    drivers.Add(driver);
                    JsonDataManager<Driver>.Save(driversFile, drivers);
                    Console.WriteLine("User registered successfully");
                }
            }
            else if (choice == "2")
            {
                User loggedInUser = null;

                while (loggedInUser == null)
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    loggedInUser = User.login(username, password, customers, admins, drivers);

                    if (loggedInUser == null)
                    {
                        Console.WriteLine("Invalid username or password, try again.\n");
                    }
                    else
                    {
                        Console.WriteLine($"Welcome {loggedInUser.name}, you logged in as {loggedInUser.role}.");
                    }
                }
                while (true)
                {
                    if (loggedInUser is Customer c)
                    {
                        while (true)
                        {
                            Console.WriteLine("=== Customer Menu ===");
                            Console.WriteLine("1. Create Order");
                            Console.WriteLine("2. View Orders");
                            Console.WriteLine("3. Add to Wallet");
                            Console.WriteLine("4. Logout");
                            string customerChoise = Console.ReadLine();
                            if (customerChoise == "1")
                            {
                                Console.WriteLine("\nAvailable Services:");
                                foreach (var s in services)
                                    Console.WriteLine($"{s.id}. {s.name} - {s.price}");
                                Console.Write("Enter services' IDs you want to order (separated by ,): ");
                                string input = Console.ReadLine();
                                string[] selected = input.Split(',');

                                List<Service> selectedServices = new List<Service>();

                                foreach (string s in selected)
                                {
                                    int id = int.Parse(s.Trim());
                                    Service foundService = null;
                                    foreach (Service service in services)
                                    {
                                        if (service.id == id)
                                        {
                                            foundService = service;
                                            break;
                                        }
                                    }
                                    if (foundService != null)
                                    {
                                        selectedServices.Add(foundService);
                                    }
                                }


                                Customer currentCustomer = (Customer)loggedInUser;
                                var createdOrder = currentCustomer.createOrder(selectedServices);
                                Console.WriteLine("Order created successfully!");
                                currentCustomer.orderPayment(createdOrder);
                                orders.Add(createdOrder);
                                JsonDataManager<Order>.Save(ordersFile, orders);

                                Customer matchedCustomer = null;
                                foreach (Customer cust in customers)
                                {
                                    if (cust.id == currentCustomer.id)
                                    {
                                        matchedCustomer = cust;
                                        break;
                                    }
                                }

                                if (matchedCustomer != null)
                                {
                                    matchedCustomer.orders = currentCustomer.orders;
                                }

                                JsonDataManager<Customer>.Save(customersFile, customers);
                            }
                            else if (customerChoise == "2") { 
                                ((Customer)loggedInUser).viewOrder();
                            }
                            else if (customerChoise == "3") {
                                Console.WriteLine("Enter the amount you want to add to your wallet:");
                                double amount = double.Parse(Console.ReadLine());
                                ((Customer)loggedInUser).addToWallet(amount);
                                foreach (Customer cust in customers)
                                {
                                    if (loggedInUser.id == cust.id)
                                    {
                                        customer.walletBalance = ((Customer)loggedInUser).walletBalance;
                                    }
                                }
                                JsonDataManager<Customer>.Save(customersFile, customers);
                            }
                            else if (customerChoise == "4") { loggedInUser.logout(); return; }
                        }
                    }
                    else if (loggedInUser is Admin a)
                    {
                        while (true)
                        {
                            Console.WriteLine("=== Admin Menu ===");
                            Console.WriteLine("1. Add Service");
                            Console.WriteLine("2. Delete Service");
                            Console.WriteLine("3. Assign Driver");
                            Console.WriteLine("4. Logout");
                            string adminChoise = Console.ReadLine();
                            if (adminChoise == "1") {
                                Console.WriteLine("Enter The service's name and price (separated by ,):");
                                string[] newService = Console.ReadLine().Split(',');
                                string serviceName = newService[0];
                                double servicePrice = double.Parse(newService[1]);
                                Service service = new Service() {name = serviceName, price = servicePrice };
                                admin.addService(services, service);
                                JsonDataManager<Service>.Save(servicesFile, services);
                            }
                            else if (adminChoise == "2") { 
                            Console.WriteLine("Enter the service's id you want to delete:");
                            int serviceId = int.Parse(Console.ReadLine());
                                bool found = false;
                                for (int i = 0; i < services.Count; i++)
                                {
                                    if (services[i].id == serviceId)
                                    {
                                        admin.deleteService(services, services[i]);
                                        Console.WriteLine($"Service with ID {serviceId} deleted successfully");
                                        JsonDataManager<Service>.Save(servicesFile, services);
                                        found = true;
                                        break; 
                                    }
                                }

                                if (!found)
                                {
                                    Console.WriteLine($"No service found with ID {serviceId}");
                                }

                            }
                            else if (adminChoise == "3") {
                                Console.WriteLine("Available Orders:");
                                foreach (var o in orders)
                                {
                                    Console.WriteLine($"Order ID: {o.id}, Status: {o.status}, Total: {o.totalCost}");
                                }

                                Console.Write("Enter Order ID to assign a driver: ");
                                int orderId = int.Parse(Console.ReadLine());

                                Order selectedOrder = null;
                                foreach (var o in orders)
                                {
                                    if (o.id == orderId)
                                    {
                                        selectedOrder = o;
                                        break;
                                    }
                                }

                                if (selectedOrder == null)
                                {
                                    Console.WriteLine("Order not found!");
                                    return;
                                }
                                Console.Write("Enter Driver ID: ");
                                int driverId = int.Parse(Console.ReadLine());

                                Driver selectedDriver = null;
                                foreach (var d in drivers)
                                {
                                    if (d.id == driverId)
                                    {
                                        selectedDriver = d;
                                        break;
                                    }
                                }

                                if (selectedDriver == null)
                                {
                                    Console.WriteLine("Driver not found!");
                                    return;
                                }
                                admin.assignDriver(selectedOrder, selectedDriver);

                                JsonDataManager<Order>.Save(ordersFile, orders);
                                JsonDataManager<Driver>.Save(driversFile, drivers);
                            }
                            else if (adminChoise == "4") { loggedInUser.logout(); return; }

                        }
                    }
                    else if (loggedInUser is Driver d)
                    {
                        while (true)
                        {
                            Console.WriteLine("=== Driver Menu ===");
                            Console.WriteLine("1. View Assigned Orders");
                            Console.WriteLine("2. Update Order Status");
                            Console.WriteLine("3. Logout");
                            string driverChoise = Console.ReadLine();
                            if (driverChoise == "1") {
                                var myOrders = driver.viewAssignedOrder(orders);
                                if (myOrders.Count == 0)
                                {
                                    Console.WriteLine($"No assigned orders for you");
                                }
                                else
                                {
                                    Console.WriteLine($"you have {myOrders.Count} orders to deliver:");
                                    foreach (var o in myOrders)
                                    {
                                        Console.WriteLine($"Order ID: {o.id}, Status: {o.status}, Total: {o.totalCost}");
                                    }
                                }
                            }
                            else if (driverChoise == "2") {
                                Console.WriteLine("Enter Order ID to update status:");
                                int orderId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter new status:");
                                string newStatus = Console.ReadLine();

                                driver.updateOrderStatus(orders, orderId, newStatus);
                                JsonDataManager<Order>.Save(ordersFile, orders);

                            }
                            else if (driverChoise == "3") { loggedInUser.logout(); return; }
                        }
                    }
                }
            }
        }
    }
}
