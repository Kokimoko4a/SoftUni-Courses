using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {

           //Day: 13, Month: Jul, Year: 1928

            string input = Console.ReadLine();
            string pattern = @"(?<day>\d{2})(?<sep>[.\-/])(?<month>[A-Z][a-z]{2})\k<sep>(?<year>\d{4})";
            Regex regex = new Regex(pattern);
            MatchCollection validOnes = regex.Matches(input);

            foreach (Match  item in validOnes )
            {
                Console.WriteLine($"Day: {item .Groups["day"]}, Month: {item.Groups["month"]}, Year: {item.Groups["year"]}");
            }
        }
    }
}
