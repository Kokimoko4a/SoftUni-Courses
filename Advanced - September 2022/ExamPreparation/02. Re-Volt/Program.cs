using System;

namespace _02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;


            for (int row = 0; row < size; row++)
            {
                string curEle = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = curEle[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    if (CoordinatesValid(matrix, playerCol - 1, playerRow, size))
                    {
                        if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                           // matrix[playerRow, playerCol - 1] = '-';
                            playerCol--;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol - 1, playerRow, size))
                            {
                                if (matrix[playerRow, playerCol - 1] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerCol--;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerCol--;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerCol = size - 1;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else if (matrix[playerRow, playerCol - 1] == 'T')
                        {
                            continue;
                        }

                        else if (matrix[playerRow, playerCol - 1] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                            playerCol--;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerCol--;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol = size - 1;

                        if (matrix[playerRow,playerCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                           // playerCol--;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }


                        else if (matrix[playerRow,playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                            // matrix[playerRow, playerCol - 1] = '-';
                            playerCol--;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol - 1, playerRow, size))
                            {
                                if (matrix[playerRow, playerCol - 1] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerCol--;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerCol--;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerCol = size - 1;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = 'f';
                        }
                       
                    }
                }

                if (command == "down")
                {
                    if (CoordinatesValid(matrix, playerCol, playerRow + 1, size))
                    {
                        if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                          //  matrix[playerRow + 1, playerCol] = '-';
                            playerRow++;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol, playerRow + 1, size))
                            {
                                if (matrix[playerRow + 1, playerCol] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerRow++;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerRow++;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerRow = 0;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else if (matrix[playerRow + 1, playerCol] == 'T')
                        {
                            continue;
                        }

                        else if (matrix[playerRow + 1, playerCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                            playerRow++;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerRow++;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = 0;

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                            //playerRow++;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }


                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                            //  matrix[playerRow + 1, playerCol] = '-';
                            playerRow++;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol, playerRow + 1, size))
                            {
                                if (matrix[playerRow + 1, playerCol] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerRow++;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerRow++;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerRow = 0;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = 'f';
                        }
                       
                    }
                }

                if (command == "right")
                {
                    if (CoordinatesValid(matrix, playerCol + 1, playerRow, size))
                    {
                        if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                            // matrix[playerRow, playerCol - 1] = '-';
                            playerCol++;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol + 1, playerRow, size))
                            {
                                if (matrix[playerRow, playerCol + 1] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerCol++;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerCol++;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerCol = 0;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else if (matrix[playerRow, playerCol + 1] == 'T')
                        {
                            continue;
                        }

                        else if (matrix[playerRow, playerCol + 1] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                            playerCol++;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerCol++;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol = 0;

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                          //  playerCol++;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else if (matrix[playerRow,playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                            // matrix[playerRow, playerCol - 1] = '-';
                            playerCol++;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol + 1, playerRow, size))
                            {
                                if (matrix[playerRow, playerCol + 1] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerCol++;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerCol++;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerCol = 0;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = 'f';
                        }
                       
                    }
                }

                if (command == "up")
                {
                    if (CoordinatesValid(matrix, playerCol, playerRow - 1, size))
                    {
                        if (matrix[playerRow - 1, playerCol] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                            //  matrix[playerRow + 1, playerCol] = '-';
                            playerRow--;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol, playerRow - 1, size))
                            {
                                if (matrix[playerRow - 1, playerCol] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerRow--;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerRow--;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerRow = size-1;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else if (matrix[playerRow - 1, playerCol] == 'T')
                        {
                            continue;
                        }

                        else if (matrix[playerRow - 1, playerCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                            playerRow--;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerRow--;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = size-1;

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = '-';
                           // playerRow--;
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix, size);
                            return;
                        }

                        else if (matrix[playerRow,playerCol ] == 'B')
                        {
                            matrix[playerRow, playerCol] = '-';
                            //  matrix[playerRow + 1, playerCol] = '-';
                            playerRow--;
                            matrix[playerRow, playerCol] = 'f';

                            if (CoordinatesValid(matrix, playerCol, playerRow - 1, size))
                            {
                                if (matrix[playerRow - 1, playerCol] == 'F')
                                {
                                    Console.WriteLine("Player won!");
                                    matrix[playerRow, playerCol] = 'B';
                                    playerRow--;
                                    matrix[playerRow, playerCol] = 'f';
                                    PrintMatrix(matrix, size);
                                    return;
                                }

                                matrix[playerRow, playerCol] = 'B';
                                playerRow--;
                                matrix[playerRow, playerCol] = 'f';
                            }

                            else
                            {
                                matrix[playerRow, playerCol] = 'B';
                                playerRow = size - 1;
                                matrix[playerRow, playerCol] = 'f';
                            }
                        }

                        else
                        {
                            matrix[playerRow, playerCol] = 'f';
                        }
                      
                    }
                }
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix, size);
        }

        private static void PrintMatrix(char[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    Console.Write(matrix[i, k]);
                }

                Console.WriteLine();
            }
        }

        private static bool CoordinatesValid(char[,] matrix,int playerCol, int playerRow, int size)
        {
            return playerRow >= 0 && playerRow < size && playerCol < size && playerCol >= 0;
        }
    }
}
