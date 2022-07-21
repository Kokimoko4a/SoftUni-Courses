using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<sep>[#|])(?<name>[A-Z a-z]+)\k<sep>(?<bb>[0-9]{2}/[0-9]{2}/[0-9]{2})\k<sep>(?<cals>[0-9]+)\k<sep>";
            Regex regex = new Regex(pattern);
            MatchCollection validOnes = regex.Matches(input);
            int totalCals = 0;
            int daysCanSurvive = 0;

            foreach (Match item in validOnes)
            {
                totalCals += int.Parse(item.Groups["cals"].ToString());
            }

            daysCanSurvive = totalCals / 2000;

            Console.WriteLine($"You have food to last you for: {daysCanSurvive} days!");

            foreach (Match item in validOnes)
            {
                Console.WriteLine($"Item: {item.Groups["name"]}, Best before: {item.Groups["bb"]}, Nutrition: {item.Groups["cals"]}");
            }
        }
    }
}
