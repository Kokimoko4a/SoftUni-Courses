using htmlToImageAndPDFConvertier.Models;
using iText.Barcodes;
using iText.Barcodes.Qrcode;
using iText.Commons.Datastructures;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using SelectPdf;
using SkiaSharp;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Metadata;
using System.Xml.Linq;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

//BORDERRRRR





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
            //tesing 


            string htmlContent = @"<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Fitness Card</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
        }

        .card {
            width: 300px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            margin: 50px auto;
        }

        .card-header {
            background-color: #3498db;
            color: #fff;
            text-align: center;
            padding: 20px;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
        }

        .card-body {
            padding: 20px;
        }

        h2 {
            margin: 0;
        }

        h3 {
            margin: 0;
        }

        .exercise, .duration, .calories, .validity {
            margin-bottom: 20px;
        }

        .exercise p, .duration p, .calories p, .validity p {
            margin: 0;
            color: #666;
        }

        .qr-code {
            text-align: center;
        }
    </style>
</head>
<body>
    <div class=""card"">
        <div class=""card-header"">
            <h2>Fitness Card</h2>
        </div>
        <div class=""card-body"">
            <div class=""exercise"">
                <h3>Exercise:</h3>
                <p>Push-ups</p>
            </div>
            <div class=""duration"">
                <h3>Duration:</h3>
                <p>30 minutes</p>
            </div>
            <div class=""calories"">
                <h3>Calories Burned:</h3>
                <p>250 kcal</p>
            </div>
            <div class=""validity"">
                <h3>Validity:</h3>
                <p>From 2024-05-01 to 2024-06-01</p>
            </div>
            <div class=""qr-code"">
                <img src=""data:image/png;base64,@ViewBag.QrCodeBase64"" alt=""QR Code"">
            </div>
        </div>
    </div>
</body>
</html>
";

            string qrCodeData = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTXDzCuZGQTUvOp2Sj7o4cHjvL-U-Zl062lfIY9DFUDK7yRLfir"; // Replace with your data
            byte[] qrCodeBytes = GenerateQrCodePng(qrCodeData);

            // Convert QR Code PNG byte array to Base64
            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);

            // Insert QR Code Base64 into HTML content
            htmlContent = htmlContent.Replace("@ViewBag.QrCodeBase64", qrCodeBase64);

            // Convert HTML to PDF as before...

            HtmlToPdf htmlToPdf = new HtmlToPdf();

            PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(htmlContent);



            byte[] bytes = pdfDocument.Save();

            return File(bytes, "application/pdf", "Your_Fitness_Card.pdf");



            /* string htmlContent = "<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Fitness Card</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f0f0f0;\r\n            margin: 0;\r\n            padding: 0;\r\n        }\r\n\r\n        .card {\r\n            width: 300px;\r\n            background-color: #fff;\r\n            border-radius: 10px;\r\n            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\r\n            margin: 50px auto;\r\n        }\r\n\r\n        .card-header {\r\n            background-color: #3498db;\r\n            color: #fff;\r\n            text-align: center;\r\n            padding: 20px;\r\n            border-top-left-radius: 10px;\r\n            border-top-right-radius: 10px;\r\n        }\r\n\r\n        .card-body {\r\n            padding: 20px;\r\n        }\r\n\r\n        h2 {\r\n            margin: 0;\r\n        }\r\n\r\n        h3 {\r\n            margin: 0;\r\n        }\r\n\r\n        .exercise, .duration, .calories, .validity {\r\n            margin-bottom: 20px;\r\n        }\r\n\r\n        .exercise p, .duration p, .calories p, .validity p {\r\n            margin: 0;\r\n            color: #666;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h2>Fitness Card</h2>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <div class=\"exercise\">\r\n                <h3>Exercise:</h3>\r\n                <p>Push-ups</p>\r\n            </div>\r\n            <div class=\"duration\">\r\n                <h3>Duration:</h3>\r\n                <p>30 minutes</p>\r\n            </div>\r\n            <div class=\"calories\">\r\n                <h3>Calories Burned:</h3>\r\n                <p>250 kcal</p>\r\n            </div>\r\n            <div class=\"validity\">\r\n                <h3>Validity:</h3>\r\n                <p>From 2024-05-01 to 2024-06-01</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n <h1>{username}</h1></html>";


             htmlContent = htmlContent.Replace("{username}", "Kaloyan");

             HtmlToPdf htmlToPdf = new HtmlToPdf();

             PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(htmlContent);



             byte[] bytes = pdfDocument.Save();





             pdfDocument.Close();

             return File(bytes, "application/pdf",
                     "Your_Fitness_Card.pdf");*/ //this works okay !!!

        }

        private byte[] GenerateQrCodePng(string qrCodeData)
        {
            var writer = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 300,
                    Margin = 0
                }
            };

            var pixelData = writer.Write(qrCodeData);
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            {
                using (var ms = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }

                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
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
