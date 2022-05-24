using System;

namespace P01.ConsoleConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal usd = decimal.Parse(Console.ReadLine());
            decimal bgn = usd * 1.79549m; //ей туй m показва че е decimal да си знаеш
            Console.WriteLine(bgn);
        }
    }
}
