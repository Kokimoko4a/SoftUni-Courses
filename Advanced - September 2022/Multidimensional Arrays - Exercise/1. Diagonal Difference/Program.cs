using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            int copyOfSize = size;
            int[,] matrix = new int[size, size];
            int primarySum = 0;
            int secondarySum = 0;

            for (int row = 0; row < size; row++)
            {
                int[] currNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currNumbers[col];
                }
            }

            for (int i = 0; i < size; i++)
            {

                primarySum += matrix[i, i];

            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (col == copyOfSize - 1)
                    {
                        secondarySum += matrix[row, col];
                        copyOfSize--;
                        break;
                    }
                }
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
