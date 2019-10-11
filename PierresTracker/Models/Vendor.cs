using System.Collections.Generic;

namespace PierresTracker.Models
{
    public class Vendor
    {
        public static List<Vendor> VendorsList = new List<Vendor>{};
        private static int _currentVendorId = 0;
        
        public string Name { get; }
        public string Description { get; }
        public int Id { get; }
        public List<Order> OrderList { get; }
        private int OrderId { get; set; }

        public Vendor(string name, string description)
        {
            Name = name;
            Description = description;
            _currentVendorId++;
            Id = _currentVendorId;
            OrderId = 0;
            OrderList = new List<Order>{};
        }

        public void AddOrder(string title, string description)
        {
            
        }
    }
}