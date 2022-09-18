using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int theBestSum = int.MinValue;
            int[,] matrix = new int[rows, cols];
            int[] theBestNumbers = new int[4];

            for (int row = 0; row < rows; row++)
            {
                int[] currNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = currNumbers[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currSum = 0;
                    currSum += matrix[row, col];
                    currSum += matrix[row, col + 1];
                    currSum += matrix[row + 1, col];
                    currSum += matrix[row + 1, col + 1];

                    if (currSum > theBestSum)
                    {
                        theBestSum = currSum;

                        theBestNumbers[0] = matrix[row, col];
                        theBestNumbers[1] = matrix[row, col + 1];
                        theBestNumbers[2] = matrix[row + 1, col];
                        theBestNumbers[3] = matrix[row + 1, col + 1];
                    }
                }
            }

            Console.WriteLine(theBestNumbers[0] + " " + theBestNumbers[1]);
            Console.WriteLine(theBestNumbers[2] + " " + theBestNumbers[3]);
            Console.WriteLine(theBestSum);
        }
    }
}
