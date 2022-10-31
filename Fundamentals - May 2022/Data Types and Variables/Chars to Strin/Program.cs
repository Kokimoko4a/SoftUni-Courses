using System;

namespace Chars_to_Strin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            char symbol3 = char.Parse(Console.ReadLine());

            Console.WriteLine($"{symbol1}{symbol2}{symbol3}");
        }
    }
}
