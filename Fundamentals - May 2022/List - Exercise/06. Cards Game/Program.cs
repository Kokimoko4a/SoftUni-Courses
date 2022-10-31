using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (first.Count > 0 && second.Count > 0)
            {
                if (first[0] > second[0])
                {
                    first.Add(second[0]);
                    first.Add(first[0]);
                }

                else if (first[0] < second[0])
                { 
                    second.Add(first[0]);
                    second.Add(second [0]);
                
                }

                first.RemoveAt(0);
                second.RemoveAt(0);

                
            }

            int sumFirst = 0;
            int sumSecond = 0;

            foreach (var card in first )
            {
                sumFirst += card;
            }

            foreach (var card in second )
            {
                sumSecond += card;
            }

            if (sumSecond >sumFirst )
            {
                Console.WriteLine($"Second player wins! Sum: {sumSecond }");
            }

            else
            {
                Console.WriteLine($"First player wins! Sum: {sumFirst}");
            }
        }

    
    }
}
