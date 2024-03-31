using malko.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace malko.Controllers
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
            return View("Igra");
        }


        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            if (file != null && file.Length > 0)
            {

                // Ensure "uploads" directory exists
                var uploadsFolder = @"D:\Kaloyan\malko\malko\wwwroot\images";
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique file name
                var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";

                // Combine uploads directory path with file name
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Open a stream to write the file to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // Copy the uploaded file data to the file stream
                    await file.CopyToAsync(fileStream);
                }

                // Optionally, you can store the file path in the database
                // For example: Save filePath to database

                // Redirect or return a success response

             
                Console.WriteLine(fileName);
                return View(new Model() { first = "images/" + fileName });


            }

            return NoContent();

        }


        public IActionResult Igra(string id1, string number, string koki)
        {
            Model model = new Model();
            model.first = id1;
            model.second = number;
            model.MyProperty = koki;

            return View("Chao", model);
        }

        public IActionResult Privacy( Model model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Model
    {

        public string first { get; set; } = null!;
        public string second { get; set; } = null!;

        public string MyProperty { get; set; } = null!;
    }
}
