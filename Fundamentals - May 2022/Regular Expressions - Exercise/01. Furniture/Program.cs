using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> furNames = new List<string>();
            double total = 0;
            string pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>[0.0-9.9]+)!(?<quan>[0-9]+)";
            Regex regex = new Regex(pattern);

            while (command != "Purchase")
            {
                string furniture = command;
                bool isMatch = regex.IsMatch(furniture);

                if (isMatch)
                {
                    Match match = regex.Match(furniture);

                    furNames.Add(match.Groups["name"].ToString());
                    double price = double.Parse(match.Groups["price"].ToString());
                    int quantity = int.Parse(match.Groups["quan"].ToString());
                    total += quantity * price;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            if (furNames.Count > 0)
            {
                Console.WriteLine(string.Join("\n", furNames));
            }

            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
