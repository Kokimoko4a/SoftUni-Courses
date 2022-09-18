using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                int[] currNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = currNumbers[col];
                }
            }

            for (int i = 0; i < size; i++)
            {
                sum+= matrix[i,i];
            }

            Console.WriteLine(sum);
        }
    }
}
