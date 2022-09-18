using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];
            int sum = 0;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currNumbers[col];
                    sum+=matrix[row, col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
