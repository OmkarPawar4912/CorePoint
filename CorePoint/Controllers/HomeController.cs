using Microsoft.AspNetCore.Mvc;

namespace CorePoint.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ComingSoon()
        {
            return View();
        }
    }
}
