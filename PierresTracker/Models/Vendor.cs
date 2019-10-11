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
        private int _orderId { get; set; }

        public Vendor(string name, string description)
        {
            Name = name;
            Description = description;
            _currentVendorId++;
            Id = _currentVendorId;
            _orderId = 0;
            OrderList = new List<Order>{};
            VendorsList.Add(this);
        }

        public void AddOrder(string title, string description, string date, List<string> itemsOrdered)
        {
            _orderId++;
            Order newOrder = new Order(_orderId, title, description,date, itemsOrdered);
            OrderList.Add(newOrder);
        }
    }
}