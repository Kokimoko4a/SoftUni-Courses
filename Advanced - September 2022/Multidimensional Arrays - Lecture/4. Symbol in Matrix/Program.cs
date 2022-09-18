using System;
using System.Diagnostics;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
          

            for (int row = 0; row < size; row++)
            {
                string text = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = text[col];
                }
            }

            char searchedSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < size; row++)
            {               
                for (int col = 0; col < size; col++)
                {
                    char currChar = matrix[row, col];

                    if (currChar == searchedSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{searchedSymbol} does not occur in the matrix ");
        }
    }
}
