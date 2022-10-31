using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] < 0)
                {
                    input.RemoveAt(i);
                    i--;
                }
            }

            if (input.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }

            input.Reverse();

            Console.WriteLine(String.Join(" ", input));
        }
    }
}
