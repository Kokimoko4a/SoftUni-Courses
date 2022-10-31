using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Maetrix(input);
        }

        private static void Maetrix(int input)
        {
            for (int i = 0; i < input ; i++)
            {
                for (int k = 0; k < input ; k++)
                {
                    Console.Write(input + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
