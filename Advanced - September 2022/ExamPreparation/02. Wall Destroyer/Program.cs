using System;
using System.Drawing;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int countOfHoles = 0;
            int vankoRow = -1;
            int vankoCol = -1;
            int hitrods = 0;

            for (int row = 0; row < size; row++)
            {
                string currElements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currElements[col];

                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;

                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "left")
                {
                    if (CellValid(vankoCol - 1, vankoRow, size))
                    {
                        char futureElement = matrix[vankoRow, vankoCol - 1];

                        if (futureElement == '-')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow, vankoCol - 1] = 'V';
                            vankoCol--;
                            countOfHoles++;
                        }

                        else if (futureElement == 'C')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow, vankoCol - 1] = 'E';
                            countOfHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++countOfHoles} hole(s).");
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else if (futureElement == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitrods++;
                        }

                        else if (futureElement == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol - 1}]!");
                            matrix[vankoRow, vankoCol] = '*';
                            vankoCol--;
                           //countOfHoles++;
                        }
                    }



                }


                else if (command == "right")
                {
                    if (CellValid(vankoCol + 1, vankoRow, size))
                    {
                        char futureElement = matrix[vankoRow, vankoCol + 1];

                        if (futureElement == '-')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow, vankoCol + 1] = 'V';
                            vankoCol++;
                            countOfHoles++;
                        }

                        else if (futureElement == 'C')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow, vankoCol + 1] = 'E';
                            countOfHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++countOfHoles} hole(s).");
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else if (futureElement == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitrods++;
                        }

                        else if (futureElement == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol + 1}]!");
                            matrix[vankoRow, vankoCol] = '*';
                            vankoCol++;
                            //countOfHoles++;
                        }
                    }



                }

                else if (command == "up")
                {
                    if (CellValid(vankoCol, vankoRow - 1, size))
                    {
                        char futureElement = matrix[vankoRow - 1, vankoCol];

                        if (futureElement == '-')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow - 1, vankoCol] = 'V';
                            vankoRow--;
                           countOfHoles++;
                        }

                        else if (futureElement == 'C')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow - 1, vankoCol] = 'E';
                            countOfHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++countOfHoles} hole(s).");
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else if (futureElement == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitrods++;
                        }

                        else if (futureElement == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow - 1}, {vankoCol}]!");
                            matrix[vankoRow, vankoCol] = '*';
                            vankoRow--;
                           // countOfHoles++;
                        }
                    }



                }

                else if (command == "down")
                {
                    if (CellValid(vankoCol, vankoRow + 1, size))
                    {
                        char futureElement = matrix[vankoRow + 1, vankoCol];

                        if (futureElement == '-')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow + 1, vankoCol] = 'V';
                            vankoRow++;
                            countOfHoles++;
                        }

                        else if (futureElement == 'C')
                        {
                            matrix[vankoRow, vankoCol] = '*';
                            matrix[vankoRow + 1, vankoCol] = 'E';
                            countOfHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {++countOfHoles} hole(s).");
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else if (futureElement == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitrods++;
                        }

                        else if (futureElement == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow + 1}, {vankoCol}]!");
                            matrix[vankoRow, vankoCol] = '*';
                            
                            vankoRow++;
                            //countOfHoles++;
                        }
                    }



                }

                command = Console.ReadLine();
            }

                Console.WriteLine($"Vanko managed to make {++countOfHoles} hole(s) and he hit only {hitrods} rod(s).");
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

        private static bool CellValid(int vankoCol, int vankoRow, int size)
        {
            return vankoCol >= 0 && vankoCol < size && vankoRow >= 0 && vankoRow < size;
        }
    }
}
