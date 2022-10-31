using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currNumbers[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split();
                string action =tokens[0];

                if (action == "swap")
                {
                    if (tokens.Length==5)
                    {
                        int row1 = int.Parse(tokens[1]);
                        int col1 = int.Parse(tokens[2]);
                        int row2 = int.Parse(tokens[3]);
                        int col2 = int.Parse(tokens[4]);

                        if (row1>=0 && row1<rows && row2 >= 0 && row2 < rows && col1 >= 0 && col1 < cols && col2 >= 0 && col2 < cols)
                        {
                            string helperFroSwapping = matrix[row1, col1];
                            matrix[row1,col1] = matrix[row2,col2];
                            matrix[row2,col2] = helperFroSwapping;

                            for (int row = 0; row < rows; row++)
                            {
                                for (int col = 0; col < cols; col++)
                                {
                                    Console.Write(matrix[row,col] + " ");
                                }

                                Console.WriteLine();
                            }
                        }

                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }
    }
}
