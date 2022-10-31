using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();
            int divider = int.Parse(Console.ReadLine());
            Predicate<int> IsDivisible = x => x % divider == 0;
            numbers.RemoveAll(IsDivisible);
            Console.WriteLine(String.Join(" ", numbers));


        }
    }
}
