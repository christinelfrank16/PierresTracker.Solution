using System.Collections.Generic;

namespace PierresTracker.Models
{
    public class Order
    {
        private static Dictionary<string,double> _inventoryPrices = CreateInventoryDictionary();
        public string Title { get; }
        public string Description { get; }
        public double Price { get; }
        public string Date { get; }
        public Dictionary<string, int> ItemsOrdered { get; }
        public int Id { get; }

        public Order(int id, string title, string description, string date, List<string> itemsOrdered)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            ItemsOrdered = GroupOrderItems(itemsOrdered);
            Price = CalculatePrice();
        }

        private static Dictionary<string,double> CreateInventoryDictionary()
        {
            Dictionary<string,double> inventoryPrices = new Dictionary<string, double>{};
            // breads
            inventoryPrices.Add("Gluten-free Loaf", 1.50);
            inventoryPrices.Add("Wheat Loaf", 1.25);
            inventoryPrices.Add("Sourdough Loaf", 2.10);
            inventoryPrices.Add("White Bread Loaf", 1.00);
            // muffins
            inventoryPrices.Add("Blueberry Muffin", 0.45);
            inventoryPrices.Add("Poppyseed Muffin", 0.30);
            inventoryPrices.Add("Apple Crumble Muffin", 0.55);
            inventoryPrices.Add("Double Chocolate Muffin", 0.65);
            // bagels
            inventoryPrices.Add("Plain Bagel", 0.55);
            inventoryPrices.Add("Blueberry Bagel", 0.65);
            inventoryPrices.Add("Salt Bagel", 0.55);
            inventoryPrices.Add("Sesame Bagel", 0.60);
            inventoryPrices.Add("Everything Bagel", 0.65);
            // cakes
            inventoryPrices.Add("Birthday Cake", 25.00);
            inventoryPrices.Add("Wedding Cake", 42.50);
            inventoryPrices.Add("Chocolate Cake", 25.00);
            inventoryPrices.Add("Cherry Cheesecake", 29.99);
            inventoryPrices.Add("Vanilla Cheesecake", 29.99);
            inventoryPrices.Add("Lavendar-Honey Cake", 32.00);

            return inventoryPrices;
        }

        private Dictionary<string, int> GroupOrderItems(List<string> itemsOrdered)
        {
            itemsOrdered.Sort();
            Dictionary<string,int> groupedItems = new Dictionary<string, int>{};
            
            for(int i=0; i<itemsOrdered.Count;i++)
            {
                if(!groupedItems.ContainsKey(itemsOrdered[i]))
                {
                    groupedItems.Add(itemsOrdered[i], 1);
                }
                else
                {
                    groupedItems[itemsOrdered[i]]++;
                }
            }

            return groupedItems;
        }

        private double CalculatePrice()
        {
            double totalPrice = 0;
            foreach(string key in ItemsOrdered.Keys)
            {
                double priceEach = _inventoryPrices[key];
                totalPrice += ItemsOrdered[key]*priceEach;
            }
            return totalPrice;
        }

        public static List<string> GetInventoryItems()
        {
            List<string> inventoryItems = new List<string>(_inventoryPrices.Keys);
            return inventoryItems;
        }
    }
}