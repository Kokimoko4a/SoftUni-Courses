using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersAndOccurences = new Dictionary<int, int>();
            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());

                if (!numbersAndOccurences.ContainsKey(currNumber))
                {
                    numbersAndOccurences.Add(currNumber, 0);
                }

                numbersAndOccurences[currNumber]++;
            }

            var theNumber = numbersAndOccurences.First(x=>x.Value%2==0);
            Console.WriteLine(theNumber.Key);
        }
    }
}
