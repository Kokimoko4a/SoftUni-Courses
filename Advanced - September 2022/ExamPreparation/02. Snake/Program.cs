using System;

namespace _02._Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int eatenFood = 0;
            int snakeCol = 0;
            int snakeRow = 0;

            int[] f = new int[] { 1, 2, 3 };
            int v = Array.BinarySearch(f,1);
            Console.WriteLine(f[v]);

            for (int row = 0; row < size; row++)
            {
                string currEles = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currEles[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeCol = col;
                        snakeRow = row;
                    }
                }
            }

            string command = Console.ReadLine();

            while (eatenFood < 10)
            {
                if (command == "left")
                {
                    if (CellValid(size, snakeRow, snakeCol - 1))
                    {
                        char theElement = matrix[snakeRow, snakeCol - 1];

                        if (theElement == '*')
                        {
                            eatenFood++;
                            matrix[snakeRow, snakeCol] = '.';
                            snakeCol--;
                            matrix[snakeRow, snakeCol] = 'S';

                            if (eatenFood == 10)
                            {
                                break;
                            }
                        }

                        else if (theElement == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, snakeCol - 1] = '.';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeCol--;
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                    }

                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {eatenFood}");
                        PrintMatrix(matrix, size);
                        return;
                    }
                }

                else if (command == "up")
                {
                    if (CellValid(size, snakeRow - 1, snakeCol))
                    {
                        char theElement = matrix[snakeRow - 1, snakeCol];

                        if (theElement == '*')
                        {
                            eatenFood++;
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow--;
                            matrix[snakeRow, snakeCol] = 'S';

                            if (eatenFood == 10)
                            {
                                break;
                            }
                        }

                        else if (theElement == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow - 1, snakeCol] = '.';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow--;
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                    }

                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {eatenFood}");
                        PrintMatrix(matrix, size);
                        return;
                    }
                }

                else if (command == "right")
                {
                    if (CellValid(size, snakeRow, snakeCol + 1))
                    {
                        char theElement = matrix[snakeRow, snakeCol + 1];

                        if (theElement == '*')
                        {
                            eatenFood++;
                            matrix[snakeRow, snakeCol] = '.';
                            snakeCol++;
                            matrix[snakeRow, snakeCol] = 'S';

                            if(eatenFood == 10)
                            {
                                break;
                            }
                        }

                        else if (theElement == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, snakeCol + 1] = '.';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeCol++;
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                    }

                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {eatenFood}");
                        PrintMatrix(matrix, size);
                        return;
                    }
                }

                else if (command == "down")
                {
                    if (CellValid(size, snakeRow + 1, snakeCol))
                    {
                        char theElement = matrix[snakeRow + 1, snakeCol];

                        if (theElement == '*')
                        {
                            eatenFood++;
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow++;
                            matrix[snakeRow, snakeCol] = 'S';

                            if (eatenFood == 10)
                            {
                                break;
                            }
                        }

                        else if (theElement == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow + 1, snakeCol] = '.';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow++;
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                    }

                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {eatenFood}");
                        PrintMatrix(matrix, size);
                        return;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {eatenFood}");
            PrintMatrix(matrix, size);
        }

        private static void PrintMatrix(char[,] matrix, int size)
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

        private static bool CellValid(int size, int snakeRow, int snakeCol)
        {
            return snakeRow >= 0 && snakeRow < size && snakeCol >= 0 && snakeCol < size;
        }
    }
}
