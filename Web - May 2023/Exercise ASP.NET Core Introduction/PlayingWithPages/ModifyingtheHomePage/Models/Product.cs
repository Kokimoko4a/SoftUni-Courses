using Microsoft.AspNetCore.Mvc;

namespace ModifyingtheHomePage.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }
    }
}
