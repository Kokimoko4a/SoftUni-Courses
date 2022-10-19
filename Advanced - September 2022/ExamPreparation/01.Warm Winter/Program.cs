using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int> sets = new List<int>();

            while (hats.Count>0 && scarfs.Count>0)
            {
                int currHat = hats.Pop();
                int currScarf = scarfs.Peek();

                if (currHat>currScarf)
                {
                    scarfs.Dequeue();
                    sets.Add(currHat + currScarf);
                }

                if (currHat == currScarf)
                {
                    scarfs.Dequeue();
                    currHat++;
                    hats.Push(currHat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
