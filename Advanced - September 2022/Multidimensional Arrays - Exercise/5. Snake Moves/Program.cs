using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            char[,] matrix = new char[rows, cols];
            string word = Console.ReadLine();
            string wordCopy = word;
            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row>0)
                {
                  
                }

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = word[col];
                    Console.Write(matrix[row,col]);
                   

                    
                }
           
            }


        }
    }
}
