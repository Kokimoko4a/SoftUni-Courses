using System;
using System.Text.RegularExpressions;
using System.Linq;
namespace _05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This is 6 ex.

            string pattern = @"(?<user>[A-Za-z0-9\-_.]+)@(?<host>[A-z\-\.]+[\.][A-z\-]+)";
            Regex regex = new Regex(pattern );
            string input = Console.ReadLine();
            bool isValid = regex.IsMatch(input);

            if (isValid )
            {
                MatchCollection  matches = regex.Matches(input);

                foreach (Match item in matches )
                {
                    Console.WriteLine(item);
                }

            }
        }
    }
}
