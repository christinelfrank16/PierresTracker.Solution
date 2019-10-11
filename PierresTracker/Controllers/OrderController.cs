using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresTracker.Models;

namespace PierresTracker.Controllers
{
    public class OrderController : Controller
    {

        [HttpGet("/vendors/{vendorId}/order/{orderId}")]
        public ActionResult Show(int vendorId, int orderId)
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            Order order = vendor.FindOrder(orderId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("vendor", vendor);
            model.Add("order", order);
            return View(model);
        }

        [HttpGet("/vendors/{vendorId}/order/new")]
        public ActionResult New(int vendorId)
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            return View(vendor);
        }

        [HttpPost("/vendors/{vendorId}")]
        public ActionResult Create(int vendorId, string title, string description, string date, List<string> item, List<int> quantity )
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            vendor.AddOrder(title, description, date, item, quantity);
            return View("../Vendor/Show", vendor);
        }

        [HttpGet("/vendors/all/order/all/summary")]
        public ActionResult Summary()
        {
            List<Vendor> allVendors = Vendor.GetAll();
            return View("../Analysis/Summary", allVendors);
        }
    }
}