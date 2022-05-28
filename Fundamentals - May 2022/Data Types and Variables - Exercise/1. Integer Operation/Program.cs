using System;
using System.Numerics;

namespace _1._Integer_Operation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            int finalSum = (first + second) / third * fourth;

            Console.WriteLine(finalSum);

        }
    }
}
