using malko.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;
using static malko.Controllers.HomeController;

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
            return View("Igra",new GymViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Upload(GymViewModel model)
        {

            //  if (model != null && model.Length > 0)
            //{

            // Ensure "uploads" directory exists
            var uploadsFolder = @"D:\Kaloyan\malko\malko\wwwroot\images";
            //    if (!Directory.Exists(uploadsFolder))
            //    {
            //        Directory.CreateDirectory(uploadsFolder);
            //    }

            //    // Generate unique file name
            //    var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";

            //    // Combine uploads directory path with file name
            //    var filePath = Path.Combine(uploadsFolder, fileName);

            //    // Open a stream to write the file to the specified path
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        // Copy the uploaded file data to the file stream
            //        await file.CopyToAsync(fileStream);
            //    }

            //    // Optionally, you can store the file path in the database
            //    // For example: Save filePath to database

            //    // Redirect or return a success response


            //    Console.WriteLine(fileName);
            //    return View(new Model() { first = "images/" + fileName });


            //}

            List<string> files = new List<string>();

            foreach (var picture in model.Pictures)
            {
                // Generate a unique file name for the picture
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

                // Determine the directory path where the picture will be saved
                var directoryPath = Path.Combine(@"D:\Kaloyan\malko\malko\wwwroot", "images", model.Name);

                // Create the directory if it doesn't exist
                Directory.CreateDirectory(directoryPath);

                // Combine directory path and file name to get the full file path
                var filePath = Path.Combine(directoryPath, fileName);

                // Save the picture to the file system
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await picture.CopyToAsync(fileStream);
                }

                string f = @"images\" + model.Name + @"\" + fileName;

                files.Add(f);
            }


            return View(files);
            //return NoContent();

        }


       /* public IActionResult Igra(string id1, string number, string koki)
        {
            
        }*/

        public IActionResult Privacy(Model model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Send()
        {
            var fromAddress = new MailAddress("kaloyan.rusev.2007@gmail.com", "Me");
            var toAddress = new MailAddress("kaloyan.rusev.2007@abv.bg", "Recipient Name");
            const string subject = "Subject of your email";
            const string body = "Body of your email";



            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("kaloyan.rusev.2007@gmail.com", "Kaloyan*2007")
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtpClient.Send(message);
            }

            return NoContent();
        }
    }


    public class GymViewModel
    {
        public string Name { get; set; } = null!;

        public List<IFormFile> Pictures { get; set; } = new List<IFormFile>();

    }
    public class Model
    {

        public string first { get; set; } = null!;
        public string second { get; set; } = null!;

        public string MyProperty { get; set; } = null!;
    }
}
