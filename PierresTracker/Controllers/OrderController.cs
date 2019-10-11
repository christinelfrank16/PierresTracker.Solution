using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresTracker.Models;

namespace PierresTracker.Controllers
{
    public class OrderController : Controller
    {

        [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
        public ActionResult Show(int vendorId, int orderId)
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            Order order = vendor.FindOrder(orderId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("vendor", vendor);
            model.Add("order", order);
            return View(model);
        }

        [HttpGet("/vendors/{vendorId}/orders/new")]
        public ActionResult New(int vendorId)
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            return View(vendor);
        }

        [HttpGet("/vendors/{vendorId}/orders")]
        public ActionResult Index(int vendorId)
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            return View(vendor);
        }

        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string title, string description, string date, List<string> itemsOrdered )
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            vendor.AddOrder(title, description, date, itemsOrdered);
            return View(vendor);
        }
    }
}