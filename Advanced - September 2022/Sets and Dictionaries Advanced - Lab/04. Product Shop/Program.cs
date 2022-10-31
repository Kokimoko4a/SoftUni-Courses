using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] tokens = command.Split(", ");
                string nameOfShop = tokens[0];
                string nameOfProduct = tokens[1];
                double priceOfProduct = double.Parse(tokens[2]);

                if (!shops.ContainsKey(nameOfShop))
                {
                    shops.Add(nameOfShop, new Dictionary<string, double>());
                }

                shops[nameOfShop].Add(nameOfProduct, priceOfProduct);

                command = Console.ReadLine();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine(shop.Key + "->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
