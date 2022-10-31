using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Custom_Comparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> evens = new List<int>();
            List<int> odds = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]%2 ==0)
                {
                    evens.Add(input[i]);
                }

                else
                {
                    odds.Add(input[i]);
                }
            }

            Console.Write(string.Join(" ", evens.OrderBy(x=>x)));
            Console.Write("");
            Console.WriteLine(string.Join(" ", odds.OrderBy(x=>x)));
        }
    }
}
