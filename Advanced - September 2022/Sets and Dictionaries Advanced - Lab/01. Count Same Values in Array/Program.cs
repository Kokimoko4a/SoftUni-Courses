using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal [] numbers = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            Dictionary < decimal,decimal> countOfEachOccurence = new Dictionary<decimal,decimal>();

            foreach (var item in numbers)
            {
                if (!countOfEachOccurence.ContainsKey(item))
                {
                    countOfEachOccurence.Add(item, 0);
                }

                countOfEachOccurence[item]++;
            }

            foreach (var item in countOfEachOccurence)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }

        }
    }
}
