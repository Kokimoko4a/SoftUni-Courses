using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<char, int> charsAndOccurences = new Dictionary<char, int>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!charsAndOccurences.ContainsKey(input[i]))
                {
                    charsAndOccurences.Add(input[i], 0);
                }

                charsAndOccurences[input[i]]++;
            }

            foreach (var item in charsAndOccurences.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }

          
        }
    }
}
