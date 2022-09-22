using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (numbers.Length<3)
            {
                Console.WriteLine(String.Join(' ', numbers.OrderByDescending(x=>x)));
            }

            else
            {
                numbers = numbers.OrderByDescending(x => x).ToArray();
                Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]}");
            }
        }
    }
}
