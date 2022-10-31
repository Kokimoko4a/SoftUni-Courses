using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            input.Sort();
            input.Reverse();

            List<int> toppers = new List<int>();
            toppers.Sort();
            toppers.Reverse();

            double average = input.Average();
            int counter = 0;

            for (int i = 0; i < input.Count; i++)
            {
                int currentNumber = input[i];
                if (currentNumber > average && counter < 5)
                {
                    toppers.Add(currentNumber);
                    counter++;
                }
            }

            if (toppers.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }          

            Console.WriteLine(String.Join(" ", toppers));
        }
    }
}
