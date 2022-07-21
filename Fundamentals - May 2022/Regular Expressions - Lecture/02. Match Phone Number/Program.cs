using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(?<sep>[ -])2\k<sep>\d{3}\k<sep>\d{4}\b";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(input);
            Console.WriteLine(string.Join(", ", matchCollection));
        }
    }
}
