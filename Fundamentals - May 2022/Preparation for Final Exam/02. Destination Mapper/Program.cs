using System;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patern = @"(?<sep>[=/])(?<destination>[A-Z]{1}[a-z A-Z]{2,})\k<sep>";
            Regex regex = new Regex(patern);
            MatchCollection matchCollection = regex.Matches(input);
            int sum = 0;
            int k = 0;

            Console.Write("Destinations: ");

            foreach (Match item in matchCollection)
            {
                k++;

                if (k == matchCollection.Count)
                {
                    Console.Write($"{item.Groups["destination"]}");
                    sum += item.Groups["destination".ToString()].Length;
                    break;
                }

                Console.Write($"{item.Groups["destination"]}, ");
                sum += item.Groups["destination".ToString()].Length;
            }

            Console.WriteLine();
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}
