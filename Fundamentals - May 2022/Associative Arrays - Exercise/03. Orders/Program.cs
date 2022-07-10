using System;
using System.Collections.Generic;

namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, int> ordersWithQuantity = new Dictionary<string, int>();
            Dictionary<string, double[]> ordersWithPrice = new Dictionary<string, double[]>();
            string command = Console.ReadLine();

            while (command != "buy")
            {
                string[] arguments = command.Split();
                string product = arguments[0];
                double price = double.Parse(arguments[1]);
                double quantity = double.Parse(arguments[2]);

                if (!ordersWithPrice.ContainsKey(product))
                {
                    ordersWithPrice.Add(product, new double[2]);
                    ordersWithPrice[product][0] = price;
                    ordersWithPrice[product][1] = quantity;

                }

                else
                {
                    ordersWithPrice[product][0] = price;
                    ordersWithPrice[product][1] += quantity;
                }

                command = Console.ReadLine();
            }

            foreach (var product in ordersWithPrice)
            {
                Console.WriteLine($"{product.Key} -> {product.Value[0] * product.Value[1]:f2}");
               
            }
        }
    }
}
