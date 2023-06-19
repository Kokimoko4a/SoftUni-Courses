using Microsoft.AspNetCore.Mvc;
using ModifyingtheHomePage.Models;
using System.Diagnostics;

namespace ModifyingtheHomePage.Controllers
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
            ViewData["0"] = "Home Page";
            ViewData["1"] = "Hello World!";
            ViewData["2"] = "This is the Home Page";

            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Result = "About Page";
            ViewBag.Maika = "This is bullshit";
            return View();
        }


        public IActionResult Numbers(decimal number) 
        {
            ViewBag.Number = number;

            return View();
        }


        public IActionResult NumbersToN()
        {
            ViewBag.Number = 2;

            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int number = 2)
        {
            ViewBag.Number = number;
            return View();
        }

        public IActionResult Hi()
        { 
            return View(new ProductViewModel());
        }

        [HttpPost]

        public IActionResult Hi(string name)
        { 
            ProductViewModel product = new ProductViewModel();

            product.Name = name;

            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}