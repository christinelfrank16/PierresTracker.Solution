using Microsoft.AspNetCore.Mvc;

namespace PierresTracker.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}