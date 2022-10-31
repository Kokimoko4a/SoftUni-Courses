using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];
            int maxSum = 0;
            //int[,] theBestMatrix = new int[3, 3];
            int[] a = new int[9];
            bool isBigger = false;

            for (int row = 0; row < rows; row++)
            {
                int[] currNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currNumbers[col];
                }
            }

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currSum = 0;
                    int currRow = row;
                    int currCol = col;
                    int[] currNums = new int[9];
                    int f = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            currSum += matrix[currRow, currCol];
                            currNums[f] = matrix[currRow, currCol];
                            currCol++;

                            f++;
                        }
                        currRow++;
                        currCol = col;
                    }

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;

                        for (int i = 0; i < currNums.Length; i++)
                        {
                            a[i] = currNums[i];
                        }
                    }
                    currSum = 0;
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            int h = 0;

            foreach (var item in a)
            {
                if (h == 3)
                {
                    Console.WriteLine();
                    h = 0;
                }

                Console.Write(item + " ");
                h++;
            }
        }
    }
}
