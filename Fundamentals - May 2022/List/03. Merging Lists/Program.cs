using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> merged = new List<int>();


            int theBigger = Math .Max (first.Count, second.Count);

            for (int i = 0; i < theBigger ; i++)
            {
                if (i<=first .Count-1)
                {
                    merged.Add(first[i]);
                }
                if (i<=second.Count -1)
                {
                    merged.Add(second[i]);
                }
               
                
            }

            Console.WriteLine(String .Join (" ", merged ));

  

        }
    }
}
