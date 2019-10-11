using System.Collections.Generic;
using System;
using System.Data;

namespace PierresTracker.Models
{
    public abstract class DataAnalysis
    {
        private static List<Vendor> _dataSource = Vendor.GetAll();

        public static DataTable CreateTable()
        {
            DataTable orderDetailTable = new DataTable("OrderDetail");

            DataColumn[] cols ={
                      new DataColumn("Vendor_Name",typeof(String)),
                      new DataColumn("Vendor_Id",typeof(Int32)),
                      new DataColumn("Date",typeof(String)),
                      new DataColumn("Order_Id",typeof(Int32)),
                      new DataColumn("Item",typeof(String)),
                      new DataColumn("UnitPrice",typeof(Decimal)),
                      new DataColumn("OrderQty",typeof(Int32)),
                      new DataColumn("LineTotal",typeof(Decimal),"UnitPrice*OrderQty")
                  };
            orderDetailTable.Columns.AddRange(cols);

            List<Object[]> rows = new List<object[]>{};
            foreach (Vendor vendor in _dataSource)
            {
                foreach (Order order in vendor.OrderList)
                {
                    foreach (KeyValuePair<string, int> item in order.ItemsOrdered)
                    {
                        rows.Add(new Object[]{vendor.Name,vendor.Id,order.Date, order.Id, item.Key, Order.GetInventoryItemPrice(item.Key),  item.Value});
                    }
                }
            }

            foreach (Object[] row in rows)
            {
                orderDetailTable.Rows.Add(row);
            }
            return orderDetailTable;
        }

    }
}