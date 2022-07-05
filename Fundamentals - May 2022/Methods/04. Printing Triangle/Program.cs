using System;

namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <=input ; i++)
            {
                PrintTriangle(i);
            }

            for (int i = input -1 ; i > 0; i--)
            {
                PrintTriangle(i);
            }
        }

        private static void PrintTriangle(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
