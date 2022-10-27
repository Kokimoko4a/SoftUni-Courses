using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        public Product(string name,decimal price)
        {
            Name = name;
            Price = price;
        }

        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
