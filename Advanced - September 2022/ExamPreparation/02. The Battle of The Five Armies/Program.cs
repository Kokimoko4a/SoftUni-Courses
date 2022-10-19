using System;
using System.Numerics;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int armyCol = -1;
            int armyRow = -1;


            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
               // matrix[row] = new char[currElements.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = matrix[row][col];

                    if (matrix[row][col] == 'A')
                    {
                        armyCol = col;
                        armyRow = row;
                    }
                }
            }

            string command = Console.ReadLine();

            while (true)
            {
                string[] tokens = command.Split();
                string direction = tokens[0];
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);

                if (direction == "right")
                {
                    if (CellValid(matrix, enemyRow, enemyCol, size))
                    {
                        matrix[enemyRow][enemyCol] = 'O';
                    }


                    if (CellValid(matrix,armyRow, armyCol + 1, size))
                    {
                        char theElement = matrix[armyRow][armyCol+1];

                        if (theElement == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[armyRow][ armyCol + 1] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol + 1}.");
                                PrintMatrix(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[armyRow][ armyCol] = '-';
                                armyCol++;
                                matrix[armyRow][ armyCol] = 'A';
                            }
                        }

                        else if (theElement == '-')
                        {
                            matrix[armyRow][armyCol] = '-';
                            armyCol++;
                            armor--;
                            matrix[armyRow][ armyCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            armor--;
                            matrix[armyRow][ armyCol] = '-';
                            matrix[armyRow][ armyCol + 1] = '-';

                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            PrintMatrix(matrix, size);
                            return;
                        }
                    }

                    else
                    {
                        armor--;
                    }


                }

                else if (direction == "up")
                {
                    if (CellValid(matrix, enemyRow, enemyCol, size))
                    {
                        matrix[enemyRow][ enemyCol] = 'O';
                    }

                    if (CellValid(matrix, armyRow - 1, armyCol, size))
                    {
                        char theElement = matrix[armyRow - 1][ armyCol];

                        if (theElement == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][ armyCol] = '-';
                                matrix[armyRow - 1][ armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow - 1};{armyCol}.");
                                PrintMatrix(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[armyRow][ armyCol] = '-';
                                armyRow--;
                                matrix[armyRow][armyCol] = 'A';
                            }
                        }

                        else if (theElement == '-')
                        {
                            matrix[armyRow][ armyCol] = '-';
                            armyRow--;
                            armor--;
                            matrix[armyRow][ armyCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            matrix[armyRow][ armyCol] = '-';
                            matrix[armyRow - 1][ armyCol] = '-';

                            armor--;
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            PrintMatrix(matrix, size);
                            return;
                        }
                    }

                    else
                    {
                        armor--;
                    }
                }

                if (direction == "left")
                {
                    if (CellValid(matrix, enemyRow, enemyCol, size))
                    {
                        matrix[enemyRow][ enemyCol] = 'O';
                    }

                    if (CellValid(matrix, armyRow, armyCol - 1, size))
                    {
                        char theElement = matrix[armyRow][ armyCol - 1];

                        if (theElement == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][ armyCol] = '-';
                                matrix[armyRow][ armyCol - 1] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow};{armyCol - 1}.");
                                PrintMatrix(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[armyRow][ armyCol] = '-';
                                armyCol--;
                                matrix[armyRow][ armyCol] = 'A';
                            }
                        }

                        else if (theElement == '-')
                        {
                            matrix[armyRow][ armyCol] = '-';
                            armyCol--;
                            armor--;
                            matrix[armyRow][ armyCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            matrix[armyRow][ armyCol] = '-';
                            matrix[armyRow][armyCol - 1] = '-';

                            armor--;
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            PrintMatrix(matrix, size);
                            return;
                        }
                    }

                    else
                    {
                        armor--;
                    }
                }

                else if (direction == "down")
                {

                    if (CellValid(matrix, enemyRow, enemyCol, size))
                    {
                        matrix[enemyRow][ enemyCol] = 'O';
                    }

                    if (CellValid(matrix, armyRow + 1, armyCol, size))
                    {
                        char theElement = matrix[armyRow + 1][ armyCol];

                        if (theElement == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][ armyCol] = '-';
                                matrix[armyRow + 1][ armyCol] = 'X';
                                Console.WriteLine($"The army was defeated at {armyRow + 1};{armyCol}.");
                                PrintMatrix(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[armyRow][ armyCol] = '-';
                                armyRow++;
                                matrix[armyRow][ armyCol] = 'A';
                            }
                        }

                        else if (theElement == '-')
                        {
                            matrix[armyRow][ armyCol] = '-';
                            armyRow++;
                            armor--;
                            matrix[armyRow][ armyCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            matrix[armyRow][ armyCol] = '-';
                            matrix[armyRow + 1][ armyCol] = '-';

                            armor--;
                            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                            PrintMatrix(matrix, size);
                            return;
                        }
                    }

                    else
                    {
                        armor--;
                    }
                }

                command = Console.ReadLine();
            }




            static void PrintMatrix(char[][] matrix, int size)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Console.Write(matrix[i][j]);
                    }

                    Console.WriteLine();
                }
            }

            static bool CellValid(char[][] matrix,int armyRow, int armyCol, int size)
            {
                if (armyRow>=0 && armyRow<size)
                {
                    return armyRow >= 0 && armyCol >= 0 && armyCol < matrix[armyRow].Length && armyRow < size;
                }
                return false;
               
            }
        }
    }
}

