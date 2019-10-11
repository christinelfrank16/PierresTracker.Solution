using System.Collections.Generic;
using System.Linq;

namespace PierresTracker.Models
{
    public class Vendor
    {
        private static List<Vendor> _vendorsList = new List<Vendor>{};
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
            _vendorsList.Add(this);
        }

        public void AddOrder(string title, string description, string date, List<string> items, List<int> quantity)
        {
            _orderId++;
            Order newOrder = new Order(_orderId, title, description,date, items, quantity);
            OrderList.Add(newOrder);
        }

        public static Vendor FindVendor(int id)
        {
            Vendor foundVendor = _vendorsList.Where(vendor => vendor.Id == id).FirstOrDefault();
            return foundVendor;
        }

        public Order FindOrder(int id)
        {
            Order foundOrder = OrderList.Where(order => order.Id == id).FirstOrDefault();
            return foundOrder;
        }

        public static List<Vendor> GetAll()
        {
            return _vendorsList;
        }
    }
}