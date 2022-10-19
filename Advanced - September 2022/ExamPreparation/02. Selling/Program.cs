using System;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;
            int money = 0;

            for (int row = 0; row < size; row++)
            {
                string currEles = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currEles[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            string command = Console.ReadLine();

            while (money < 50)
            {
                if (command == "left")
                {
                    if (CellValid(matrix, size, playerCol - 1, playerRow))
                    {
                        char theElement = matrix[playerRow, playerCol - 1];

                        if (theElement == 'O')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol - 1] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        playerCol = col;
                                        playerRow = row;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            matrix[playerRow, playerCol] = '-';
                            money += int.Parse(matrix[playerRow, playerCol - 1].ToString());
                            playerCol--;
                            matrix[playerRow, playerCol] = 'S';

                            if (money >= 50)
                            {
                                break;
                            }

                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerCol--;
                            matrix[playerRow, playerCol] = 'S';
                        }
                    }

                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrx(matrix, size);
                        return;
                    }
                }

                else if (command == "up")
                {
                    if (CellValid(matrix, size, playerCol, playerRow - 1))
                    {
                        char theElement = matrix[playerRow - 1, playerCol];

                        if (theElement == 'O')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow - 1, playerCol] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        playerCol = col;
                                        playerRow = row;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            matrix[playerRow, playerCol] = '-';
                            money += int.Parse(matrix[playerRow - 1, playerCol].ToString());
                            playerRow--;
                            matrix[playerRow, playerCol] = 'S';

                            if (money >= 50)
                            {
                                break;
                            }

                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerRow--;
                            matrix[playerRow, playerCol] = 'S';
                        }
                    }

                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrx(matrix, size);
                        return;
                    }
                }

                else if (command == "right")
                {
                    if (CellValid(matrix, size, playerCol + 1, playerRow))
                    {
                        char theElement = matrix[playerRow, playerCol + 1];

                        if (theElement == 'O')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol + 1] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        playerCol = col;
                                        playerRow = row;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            matrix[playerRow, playerCol] = '-';
                            money += int.Parse(matrix[playerRow, playerCol + 1].ToString());
                            playerCol++;
                            matrix[playerRow, playerCol] = 'S';

                            if (money >= 50)
                            {
                                break;
                            }

                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerCol++;
                            matrix[playerRow, playerCol] = 'S';
                        }
                    }

                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrx(matrix, size);
                        return;
                    }
                }

                else if (command == "down")
                {
                    if (CellValid(matrix, size, playerCol, playerRow + 1))
                    {
                        char theElement = matrix[playerRow + 1, playerCol];

                        if (theElement == 'O')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow + 1, playerCol] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        playerCol = col;
                                        playerRow = row;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            matrix[playerRow, playerCol] = '-';
                            money += int.Parse(matrix[playerRow + 1, playerCol].ToString());
                            playerRow++;
                            matrix[playerRow, playerCol] = 'S';

                            if (money >= 50)
                            {
                                break;
                            }

                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerRow++;
                            matrix[playerRow, playerCol] = 'S';
                        }
                    }

                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        matrix[playerRow, playerCol] = '-';
                        PrintMatrx(matrix, size);
                        return;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {money}");
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

        private static bool CellValid(char[,] matrix, int size, int playerCol, int playerRow)
        {
            return playerRow >= 0 && playerRow < size && playerCol < size && playerCol >= 0;
        }
    }
}
