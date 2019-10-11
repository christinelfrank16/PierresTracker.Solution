using System.Collections.Generic;

namespace PierresTracker.Models
{
    public abstract class DataAnalysis
    {
        private static List<Vendor> dataSource = Vendor.GetAll();
        private static List<string> columnNames = new List<string>{"Vendor", "Date", "Item", "Qty","Price"};
        public static Dictionary<string, double[]> GroupData()
        {
            Dictionary<string, double[]> groupedData = new Dictionary<string, double[]>{};
            foreach(Vendor vendor in dataSource)
            {
                foreach(Order order in vendor.OrderList)
                {
                    foreach(KeyValuePair<string, int> item in order.ItemsOrdered)
                    {
                        string groupName = vendor.Name + "_" + order.Date + "_" + item.Key;
                        double[] value = new double[]{item.Value,Order.GetInventoryItemPrice(item.Key)*item.Value};
                        groupedData.Add(groupName, value);
                    }
                }
            }
            return groupedData;
        }

        public static string ParseDataName(string groupedDataName, int column)
        {
            string colValue = "";
            if(column == 0)
            {
                colValue = groupedDataName.Substring(0, groupedDataName.IndexOf("_"));
            }
            else if(column == 2)
            {
                colValue = groupedDataName.Substring(groupedDataName.LastIndexOf("_")+1);
            }
            else{
                colValue = groupedDataName.Substring(groupedDataName.IndexOf("_")+1, groupedDataName.LastIndexOf("_"));
            }
            return colValue;
        }

    }
}