using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> odder = x => x % 2 != 0;
            Predicate<int> evener = x => x % 2 == 0;

            List<int> borders = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string evenOrOdd = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = borders[0]; i <= borders[1]; i++)
            {
                numbers.Add(i);
            }


            if (evenOrOdd == "odd")
            {
                Console.WriteLine(string.Join(" ",numbers.FindAll(odder)));
            }

            else
            {
                Console.WriteLine(string.Join(" ", numbers.FindAll(evener)));
            }
          
        }
    }
}
