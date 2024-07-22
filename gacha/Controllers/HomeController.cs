using gacha.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gacha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GetPicture()
        {
            return View();
        }
        public IActionResult PointList()
        { 
            return View();
        }
        public IActionResult GachaDetailList()
        {
            return View();
        }
        public IActionResult TrackingList()
        {
            return View();
        }
        public IActionResult UserInfo()
        {
            return View();
        }
        public IActionResult GachaMachine()
        {
            return View();
        }
        public IActionResult GachaProduct()
        {
            return View();
        }
        public IActionResult Bag()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
