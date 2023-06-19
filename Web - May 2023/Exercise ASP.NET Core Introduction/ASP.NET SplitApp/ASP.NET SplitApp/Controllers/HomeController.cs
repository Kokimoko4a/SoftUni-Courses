using ASP.NET_SplitApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace ASP.NET_SplitApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static IEnumerable<string> words = new List<string>();  

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextViewModel model)
        {
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {

            
                var splittedText = model.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                model.SplitText = string.Join(Environment.NewLine, splittedText);

                return RedirectToAction("Index", model);



        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}