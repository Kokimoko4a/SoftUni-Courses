using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> numbers = new SortedDictionary<int, int>();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var number in input)
            {

                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }

                else
                {
                    numbers.Add(number, 1);
                }

            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
