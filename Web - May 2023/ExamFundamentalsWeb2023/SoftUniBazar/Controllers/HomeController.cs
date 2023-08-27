using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Contracts;
using SoftUniBazar.Models;
using System.Diagnostics;

namespace SoftUniBazar.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdService adService;

        public HomeController(IAdService adService)
        {
            this.adService = adService;
        }

        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Ad",adService.GetAllAds());
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}