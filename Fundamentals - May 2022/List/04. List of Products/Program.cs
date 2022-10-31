using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfProducts = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < countOfProducts ; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();
            int currentProduct = 0;

            foreach (var product in products )
            {
                currentProduct++;    
                Console.WriteLine($"{ currentProduct }.{product }");
             
            } 
        }
    }
}
