using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Data_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfArrays = int.Parse(Console.ReadLine());
            List<int> average = new List<int>();

            for (int i = 0; i < countOfArrays; i++)
            {
                List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
                double currAvg = numbers.Average();
                int avgRounded = (int)Math.Ceiling(currAvg);
                average.Add(avgRounded);
            }

            int filter = int.Parse(Console.ReadLine());

            for (int i = 0; i < average.Count; i++)
            {
                int num = average[i];

                if (num != 0 && num % filter == 0)
                {
                    average.Remove(num);
                    i--;
                }
            }












            int final = average.Min();

            if (final > 0)
            {
                Console.WriteLine($"The inputs seem to be positively weighted. Positive weight: {final }");
            }

            else if (final < 0)
            {
                Console.WriteLine($"The inputs seem to be negatively weighted.Negative weight: { final }");
            }

            else
            {
                Console.WriteLine($"The inputs seem to be perfectly balanced, as all things should be.Count of all arrays:{countOfArrays}.");
            }
        }
    }
}
