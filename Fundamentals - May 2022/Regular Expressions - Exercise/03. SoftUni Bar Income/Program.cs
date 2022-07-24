using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[0.0-9.9]+)\$";
            Regex regex = new Regex(pattern);
            string command = Console.ReadLine();
            double totalIncome = 0;

            while (command != "end of shift")
            {
                bool isMatch = regex.IsMatch(command);

                if (isMatch)
                {
                    Match match = regex.Match(command);
                    double total = double.Parse(match.Groups["price"].ToString()) * int.Parse(match.Groups["quantity"].ToString());
                    Console.WriteLine($"{match.Groups["name"]}: {match.Groups["product"]} - {total:f2}");
                    totalIncome += total;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
