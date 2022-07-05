using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
            List<int> realNumbers = new List<int>();


            foreach (var item in numbers )
            {
                realNumbers.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            }

            Console.WriteLine(string .Join (" ", realNumbers ));
        }
    }
}
