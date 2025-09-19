using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<Service> ServicesList { get; set; }
        public Driver AssignedDriver { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; private set; }
        public Order(int orderId, Customer customer, List<Service> servicesList)
        {
            OrderId = orderId;
            Customer = customer;
            ServicesList = servicesList;
            Status = "Placed"; // Initial status [cite: 70]
            CalculateTotalAmount();
        }
        private void CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var service in ServicesList)
            {
                TotalAmount += service.Price;
            }
        }
        public void AssignDriver(Driver driver)
        {
            AssignedDriver = driver;
        }
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }
    }
}
