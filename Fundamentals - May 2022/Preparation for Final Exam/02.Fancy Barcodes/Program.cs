using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfBarCodes = int.Parse(Console.ReadLine());
            string pattern = @"@#{1,}(?<bar>[A-Z][a-z A-Z 0-9)]{4,}[A-Z])@#{1,}";
            Regex regex = new Regex(pattern);

            for (int i = countOfBarCodes - 1; i >= 0; i--)
            {
                string currCode = Console.ReadLine();
                bool isValid = regex.IsMatch(currCode);

                if (isValid)
                {
                    Match currMatch = regex.Match(currCode);
                    StringBuilder group = new StringBuilder();
                    string currMatchAsString = currMatch.ToString();

                    foreach (var item in currMatchAsString)
                    {
                        if (char.IsDigit(item))
                        {
                            group.Append(item);
                        }
                    }

                    if (group.Length == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }

                    else
                    {
                        Console.WriteLine($"Product group: {group}");
                    }
                }

                else if (!isValid)
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
