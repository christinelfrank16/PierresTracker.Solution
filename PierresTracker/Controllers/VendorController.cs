using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresTracker.Models;

namespace PierresTracker.Controllers
{
    public class VendorController : Controller
    {

        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendor> vendorList = Vendor.GetAll();
            return View(vendorList);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            List<Vendor> vendorList = Vendor.GetAll();
            return View(vendorList);
        }

        [HttpPost("/vendors/new")]
        public ActionResult Create(string name, string description)
        {
            Vendor newVendor = new Vendor(name,description);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Vendor vendor = Vendor.FindVendor(id);
            return View(vendor);
        }
    }
}