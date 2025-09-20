using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DryCleanSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Service> source = new List<Service>();

            //string jsonString = File.ReadAllText("D:\\DEPI (full stack .net web development)\\oop_project\\dry_clean_system\\DryCleanSystem\\DryCleanSystem\\services.json");
            //source = JsonSerializer.Deserialize<List<Service>>(jsonString);

            //Console.WriteLine(source.Count);

            //foreach (Service service in source) {
            //    Console.WriteLine(service.id);
            //    Console.WriteLine(service.name);
            //    Console.WriteLine(service.price);
            //    Console.WriteLine("========================");
            //}

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


            while (true)
            {
                Console.WriteLine("\n------- Dry Clean System -------");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
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


                        //while (true) {
                        //    Console.WriteLine("1. Create Order");
                        //    Console.WriteLine("2. Pay for order");
                        //    Console.WriteLine("3. view order");
                        //    Console.WriteLine("4. Add to wallet");
                        //    Console.Write("Choose: ");
                        //    string customerChoice = Console.ReadLine();
                        //    if (customerChoice == "1") {
                        //        List<Service> availableServices = JsonDataManager<Service>.Load(servicesFile);
                        //        Console.WriteLine("Available Services:");
                        //        foreach (var service in availableServices)
                        //        {
                        //            Console.WriteLine($"{service.id}. {service.name} - {service.price}");
                        //        }
                        //        Console.WriteLine("Enter service numbers separated by comma:");
                        //        string input = Console.ReadLine();
                        //        string[] selected = input.Split(',');

                        //        List<Service> selectedServices = new List<Service>();
                        //        foreach (var s in selected)
                        //        {
                        //            int id = int.Parse(s.Trim());
                        //            var service = availableServices.Find(x => x.Id == id);
                        //            if (service != null)
                        //                selectedServices.Add(service);
                        //        }

                        //        customer.createOrder(selectedServices);
                        //        Console.WriteLine("Order created successfully!");
                        //    }
                        //}
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
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    


                    
                }
                else if (choice == "3")
                {
                    break;
                }
            }
        }
    }
}
