using System;

namespace _02.Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < size; row++)
            {

                string currEle = Console.ReadLine();
                matrix[row] = new char[currEle.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currEle[col];

                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (true)
            {
                string[] tokens = command.Split();

                if (tokens[0] == "W")
                {
                    lives--;

                    matrix[int.Parse(tokens[1])][int.Parse(tokens[2])] = 'B';

                    if (ValidCell(size, marioCol, marioRow - 1, matrix))
                    {
                        char theElement = matrix[marioRow - 1][marioCol];

                        if (theElement == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';

                                marioRow--;

                                matrix[marioRow][marioCol] = 'X';

                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                PrintMatrx(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[marioRow][marioCol] = '-';
                                marioRow--;
                                matrix[marioRow][marioCol] = 'M';
                            }
                        }

                        else if (theElement == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioRow--;
                            matrix[marioRow][marioCol] = '-';

                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrx(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioRow--;
                            matrix[marioRow][marioCol] = 'M';
                        }
                    }
                }

                else if (tokens[0] == "A")
                {
                    lives--;

                    matrix[int.Parse(tokens[1])][int.Parse(tokens[2])] = 'B';

                    if (ValidCell(size, marioCol - 1, marioRow, matrix))
                    {
                        char theElement = matrix[marioRow][marioCol - 1];

                        if (theElement == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';

                                marioCol--;

                                matrix[marioRow][marioCol] = 'X';

                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                PrintMatrx(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[marioRow][marioCol] = '-';
                                marioCol--;
                                matrix[marioRow][marioCol] = 'M';
                            }
                        }

                        else if (theElement == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioCol--;
                            matrix[marioRow][marioCol] = '-';

                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrx(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioCol--;
                            matrix[marioRow][marioCol] = 'M';
                        }
                    }
                }

                if (tokens[0] == "S")
                {
                    lives--;

                    matrix[int.Parse(tokens[1])][int.Parse(tokens[2])] = 'B';

                    if (ValidCell(size, marioCol, marioRow + 1, matrix))
                    {
                        char theElement = matrix[marioRow + 1][marioCol];

                        if (theElement == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';

                                marioRow++;

                                matrix[marioRow][marioCol] = 'X';

                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                PrintMatrx(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[marioRow][marioCol] = '-';
                                marioRow++;
                                matrix[marioRow][marioCol] = 'M';
                            }
                        }

                        else if (theElement == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioRow++;
                            matrix[marioRow][marioCol] = '-';

                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrx(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioRow++;
                            matrix[marioRow][marioCol] = 'M';
                        }
                    }
                }

                else if (tokens[0] == "D")
                {
                    lives--;

                    matrix[int.Parse(tokens[1])][int.Parse(tokens[2])] = 'B';

                    if (ValidCell(size, marioCol + 1, marioRow, matrix))
                    {
                        char theElement = matrix[marioRow][marioCol + 1];

                        if (theElement == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';

                                marioCol++;

                                matrix[marioRow][marioCol] = 'X';

                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                PrintMatrx(matrix, size);
                                return;
                            }

                            else
                            {
                                matrix[marioRow][marioCol] = '-';
                                marioCol++;
                                matrix[marioRow][marioCol] = 'M';
                            }
                        }

                        else if (theElement == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioCol++;
                            matrix[marioRow][marioCol] = '-';

                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            PrintMatrx(matrix, size);
                            return;
                        }

                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            marioCol++;
                            matrix[marioRow][marioCol] = 'M';
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }



        private static void PrintMatrx(char[][]matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < matrix[i].Length; k++)
                {
                    Console.Write(matrix[i][k]);
                }

                Console.WriteLine();
            }
        }

        private static bool ValidCell(int size, int marioCol, int marioRow, char[][] matrix)
        {
            if (marioRow < size && marioRow >= 0)
            {
                return marioRow >= 0 && marioCol >= 0 && marioRow < size && marioCol < matrix[marioRow].Length;
            }

            return false;


        }
    }
}
