using System;
using System.Linq;

namespace _02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int cols = dimensions[1];
            int rows = dimensions[0];
            int[,] matrix = new int[rows, cols];

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                string[] tokens = command.Split();
                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);

                if (row >= 0 && row < rows && col >= 0 && col < cols)
                {
                    matrix[row, col] += 1;

                    for (int row1 = row+1; row1 < rows; row1++) // down
                    {
                        matrix[row1, col]++;
                    }

                    for (int row1 = row-1; row1 >=0; row1--) // up
                    {
                        matrix[row1, col]++;
                    }

                    for (int col1 = col-1; col1 >= 0; col1--) // left
                    {
                        matrix[row, col1]++;
                    }

                    for (int col1 = col+1; col1 < cols; col1++) // right
                    {
                        matrix[row, col1]++;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                command = Console.ReadLine();
            }

            PrintMatrx(matrix, cols, rows);
        }

     
        private static void PrintMatrx(int[,] matrix, int cols, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
