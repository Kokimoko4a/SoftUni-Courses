using System;

namespace Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string lastName = Console.ReadLine();
            string symbol = Console.ReadLine();
            Console.WriteLine($"{name}{symbol}{lastName}");
        }
    }
}
