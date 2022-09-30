using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> adder = names =>
            {
                for (int i = 0; i < names.Length; i++)
                {
                    Console.Write("Sir ");
                    Console.WriteLine(names[i]);
                }
            };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            adder(names);
        }
    }
}
