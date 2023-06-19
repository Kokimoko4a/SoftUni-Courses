using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Net.Http.Headers;
using ModifyingtheHomePage.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModifyingtheHomePage.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
         new ProductViewModel()
         {
              Id  = 1,
              Name = "Milk",
              Price = 12
         },

           new ProductViewModel()
         {
              Id  = 2,
              Name = "Burger",
              Price = 7
         },

             new ProductViewModel()
         {
              Id  = 3,
              Name = "Water",
              Price = 1
         }

        };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                List<ProductViewModel> result = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
                return View(result);
            }

            return View(products);


        }

        public IActionResult ById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);

        }

        public IActionResult AllAsJson()
        {
            string result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return Json(result);
        }

        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in products)
            {
                sb.AppendLine($"Product:{item.Name} with Id {item.Id} costs:{item.Price}lv.");
            }

            return Content(sb.ToString().TrimEnd());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in products)
            {
                sb.AppendLine($"Product:{item.Name} with Id {item.Id} costs:{item.Price}lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
