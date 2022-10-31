using System;
using System.Linq;

namespace _02._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            char[,] matrix = new char[size, size];
            int carRow = 0;
            int carCol = 0;
            int distance = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currEles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currEles[col];
                }
            }

            matrix[0, 0] = 'C';

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "left")
                {
                    char theElement = matrix[carRow, carCol - 1];

                    if (theElement == 'T')
                    {
                        matrix[carRow, carCol] = '.';
                        matrix[carRow, carCol - 1] = '.';
                        distance += 30;

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'T')
                                {
                                    matrix[row, col] = 'C';
                                    carRow = row;
                                    carCol = col;
                                }
                            }
                        }
                    }

                    else if (theElement == 'F')
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carCol--;
                        matrix[carRow, carCol] = 'C';
                        Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                        Console.WriteLine($"Distance covered {distance} km.");
                        PrintMatrx(matrix, size);
                        return;
                    }

                    else
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carCol--;
                        matrix[carRow, carCol] = 'C';
                    }
                }

                else if (command == "up")
                {
                    char theElement = matrix[carRow - 1, carCol];

                    if (theElement == 'T')
                    {
                        matrix[carRow, carCol] = '.';
                        matrix[carRow - 1, carCol] = '.';
                        distance += 30;

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'T')
                                {
                                    matrix[row, col] = 'C';
                                    carRow = row;
                                    carCol = col;
                                }
                            }
                        }
                    }

                    else if (theElement == 'F')
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carRow--;
                        matrix[carRow, carCol] = 'C';
                        Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                        Console.WriteLine($"Distance covered {distance} km.");
                        PrintMatrx(matrix, size);
                        return;
                    }

                    else
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carRow--;
                        matrix[carRow, carCol] = 'C';
                    }
                }

                else if (command == "right")
                {
                    char theElement = matrix[carRow, carCol + 1];

                    if (theElement == 'T')
                    {
                        matrix[carRow, carCol] = '.';
                        matrix[carRow, carCol + 1] = '.';
                        distance += 30;

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'T')
                                {
                                    matrix[row, col] = 'C';
                                    carRow = row;
                                    carCol = col;
                                }
                            }
                        }
                    }

                    else if (theElement == 'F')
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carCol++;
                        matrix[carRow, carCol] = 'C';
                        Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                        Console.WriteLine($"Distance covered {distance} km.");
                        PrintMatrx(matrix, size);
                        return;
                    }

                    else
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carCol++;
                        matrix[carRow, carCol] = 'C';
                    }
                }

                else if (command == "down")
                {
                    char theElement = matrix[carRow + 1, carCol];

                    if (theElement == 'T')
                    {
                        matrix[carRow, carCol] = '.';
                        matrix[carRow + 1, carCol] = '.';
                        distance += 30;

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'T')
                                {
                                    matrix[row, col] = 'C';
                                    carRow = row;
                                    carCol = col;
                                }
                            }
                        }
                    }

                    else if (theElement == 'F')
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carRow++;
                        matrix[carRow, carCol] = 'C';
                        Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                        Console.WriteLine($"Distance covered {distance} km.");
                        PrintMatrx(matrix, size);
                        return;
                    }

                    else
                    {
                        distance += 10;
                        matrix[carRow, carCol] = '.';
                        carRow++;
                        matrix[carRow, carCol] = 'C';
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Racing car {racingNumber} DNF.");
            Console.WriteLine($"Distance covered {distance} km.");
            PrintMatrx(matrix, size);
        }

        private static void PrintMatrx(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
