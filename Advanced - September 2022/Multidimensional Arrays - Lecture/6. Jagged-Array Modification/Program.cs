using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currNumbers[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Add")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int numberToAdd = int.Parse(tokens[3]);

                    if (row >= 0 && row < size && col >= 0 && col < size)
                    {
                        matrix[row, col] += numberToAdd;
                    }

                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                else if (action == "Subtract")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int numberToSubstract = int.Parse(tokens[3]);

                    if (row >= 0 && row < size && col >= 0 && col < size)
                    {
                        matrix[row, col] -= numberToSubstract;
                    }

                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
