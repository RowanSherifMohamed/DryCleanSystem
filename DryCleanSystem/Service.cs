using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Service(int serviceId, string name, decimal price)
        {
            ServiceId = serviceId;
            Name = name;
            Price = price;
        }
    }
}
