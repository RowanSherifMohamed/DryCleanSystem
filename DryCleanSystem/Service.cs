using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Service
    {
        private static int counter = 1;
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        Service() { 
          id = ++counter;
        }

        public void dispalyService() {
            Console.WriteLine($"Service ID: {id}");
            Console.WriteLine($"Service Name: {name}");
            Console.WriteLine($"Service Price: {price}");
        }
    }
}
