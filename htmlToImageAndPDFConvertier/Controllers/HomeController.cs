using htmlToImageAndPDFConvertier.Models;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System.Diagnostics;


namespace htmlToImageAndPDFConvertier.Controllers
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

        public IActionResult GetPhoto()
        {
            string htmlContent = "<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Fitness Card</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f0f0f0;\r\n            margin: 0;\r\n            padding: 0;\r\n        }\r\n\r\n        .card {\r\n            width: 300px;\r\n            background-color: #fff;\r\n            border-radius: 10px;\r\n            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\r\n            margin: 50px auto;\r\n        }\r\n\r\n        .card-header {\r\n            background-color: #3498db;\r\n            color: #fff;\r\n            text-align: center;\r\n            padding: 20px;\r\n            border-top-left-radius: 10px;\r\n            border-top-right-radius: 10px;\r\n        }\r\n\r\n        .card-body {\r\n            padding: 20px;\r\n        }\r\n\r\n        h2 {\r\n            margin: 0;\r\n        }\r\n\r\n        h3 {\r\n            margin: 0;\r\n        }\r\n\r\n        .exercise, .duration, .calories, .validity {\r\n            margin-bottom: 20px;\r\n        }\r\n\r\n        .exercise p, .duration p, .calories p, .validity p {\r\n            margin: 0;\r\n            color: #666;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h2>Fitness Card</h2>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <div class=\"exercise\">\r\n                <h3>Exercise:</h3>\r\n                <p>Push-ups</p>\r\n            </div>\r\n            <div class=\"duration\">\r\n                <h3>Duration:</h3>\r\n                <p>30 minutes</p>\r\n            </div>\r\n            <div class=\"calories\">\r\n                <h3>Calories Burned:</h3>\r\n                <p>250 kcal</p>\r\n            </div>\r\n            <div class=\"validity\">\r\n                <h3>Validity:</h3>\r\n                <p>From 2024-05-01 to 2024-06-01</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>";


            HtmlToPdf htmlToPdf = new HtmlToPdf();

            PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(htmlContent);

            byte[] bytes = pdfDocument.Save();

            pdfDocument.Close();

            return File(bytes, "application/pdf",
                    "Your_Fitness_Card.pdf");

        }

        public IActionResult Privacy()
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
