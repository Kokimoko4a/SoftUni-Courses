using System;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 8;
            char[,] matrix = new char[size, size];
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;
            int turn = 0;
            string winCoordinates = string.Empty;

            for (int row = 0; row < size; row++)
            {
                string currElements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currElements[col];

                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    else if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            while (true)
            {
                if (turn % 2 == 0)
                {
                    if (CellValid(whiteRow - 2, whiteCol, size))
                    {
                        if (whiteRow > 0 && whiteCol > 0)
                        {
                            if (matrix[whiteRow - 1, whiteCol - 1] == 'b')
                            {
                                string winningCol = GetCoordinates(blackCol);
                                winCoordinates += winningCol;
                                winCoordinates += (8 - blackRow).ToString();

                                Console.WriteLine($"Game over! White capture on {winCoordinates}.");
                                return;
                            }
                        }

                        if (whiteRow > 0 && whiteCol < 7)
                        {
                            if (matrix[whiteRow - 1, whiteCol + 1] == 'b')
                            {
                                string winningCol = GetCoordinates(blackCol);
                                winCoordinates += winningCol;
                                winCoordinates += (8 - blackRow).ToString();

                                Console.WriteLine($"Game over! White capture on {winCoordinates}.");

                                return;
                            }
                        }

                        matrix[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        matrix[whiteRow, whiteCol] = 'w';
                    }

                    else
                    {
                        string winningCol = GetCoordinates(whiteCol);
                        winCoordinates += winningCol;
                        winCoordinates += 8.ToString();

                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {winCoordinates}.");
                        return;
                    }
                }

                else
                {
                    if (CellValid(blackRow + 2, blackCol, size))
                    {
                        if (blackRow < 7 && blackCol > 0)
                        {
                            if (matrix[blackRow + 1, blackCol - 1] == 'w')
                            {
                                string winningCol = GetCoordinates(whiteCol);
                                winCoordinates += winningCol;
                                winCoordinates += (8 - whiteRow).ToString();

                                Console.WriteLine($"Game over! Black capture on {winCoordinates}.");

                                return;
                            }

                        }

                        if (blackRow < 7 && blackCol < 7)
                        {
                            if (matrix[blackRow + 1, blackCol + 1] == 'w')
                            {
                                string winningCol = GetCoordinates(whiteCol);
                                winCoordinates += winningCol;
                                winCoordinates += (8 - whiteRow).ToString();

                                Console.WriteLine($"Game over! Black capture on {winCoordinates}.");

                                return;
                            }
                        }

                        matrix[blackRow, blackCol] = '-';
                        blackRow++;
                        matrix[blackRow, blackCol] = 'b';
                    }

                    else
                    {
                        string winningCol = GetCoordinates(blackCol);
                        winCoordinates += winningCol;
                        winCoordinates += 1.ToString();

                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {winCoordinates}.");

                        return;
                    }
                }

                turn++;
            }
        }

        private static string GetCoordinates(int col)
        {
            string finalCol = string.Empty;

            if (col == 0)
            {
                finalCol = "a";
            }

            else if (col == 1)
            {
                finalCol = "b";
            }

            else if (col == 2)
            {
                finalCol = "c";
            }

            else if (col == 3)
            {
                finalCol = "d";
            }

            else if (col == 4)
            {
                finalCol = "e";
            }

            else if (col == 5)
            {
                finalCol = "f";
            }

            else if (col == 6)
            {
                finalCol = "g";
            }

            else if (col == 7)
            {
                finalCol = "h";
            }

            return finalCol;
        }

        private static bool CellValid(int row, int col, int size)
        {
            return row >= 0 && col >= 0 && row < size && col < size;
        }
    }
}
