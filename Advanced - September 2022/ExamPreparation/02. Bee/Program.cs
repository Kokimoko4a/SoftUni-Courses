using System;

namespace _02._Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int beeRow = 0;
            int beeCol = 0;
            int polinatedFlowers = 0;


            for (int row = 0; row < size; row++)
            {
                string currEles = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currEles[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeCol = col;
                        beeRow = row;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "left")
                {
                    if (CellValid(beeCol - 1, beeRow, size))
                    {
                        char theElement = matrix[beeRow, beeCol - 1];

                        if (theElement == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow, beeCol] = '.';
                            beeCol--;
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else if (theElement == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, beeCol - 1] = '.';
                            beeCol -= 2;

                            if (matrix[beeRow, beeCol] == 'f')
                            {
                                polinatedFlowers++;

                            }
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol--;
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }

                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[beeRow, beeCol] = '.';
                        //PrintMatrix(size, matrix);
                        break;
                    }
                }

                else if (command == "up")
                {
                    if (CellValid(beeCol, beeRow - 1, size))
                    {
                        char theElement = matrix[beeRow - 1, beeCol];

                        if (theElement == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow, beeCol] = '.';
                            beeRow--;
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else if (theElement == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow - 1, beeCol] = '.';
                            beeRow -= 2;

                            if (matrix[beeRow, beeCol] == 'f')
                            {
                                polinatedFlowers++;

                            }
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow--;
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }

                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[beeRow, beeCol] = '.';
                        // PrintMatrix(size, matrix);
                        break;
                    }
                }

                else if (command == "right")
                {
                    if (CellValid(beeCol + 1, beeRow, size))
                    {
                        char theElement = matrix[beeRow, beeCol + 1];

                        if (theElement == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow, beeCol] = '.';
                            beeCol++;
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else if (theElement == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, beeCol + 1] = '.';
                            beeCol += 2;

                            if (matrix[beeRow, beeCol] == 'f')
                            {
                                polinatedFlowers++;

                            }
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol++;
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }

                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[beeRow, beeCol] = '.';
                        //PrintMatrix(size, matrix);
                        break;
                    }
                }

                else if (command == "down")
                {
                    if (CellValid(beeCol, beeRow + 1, size))
                    {
                        char theElement = matrix[beeRow + 1, beeCol];

                        if (theElement == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow, beeCol] = '.';
                            beeRow++;
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else if (theElement == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow + 1, beeCol] = '.';
                            beeRow += 2;

                            if (matrix[beeRow, beeCol] == 'f')
                            {
                                polinatedFlowers++;

                            }
                            matrix[beeRow, beeCol] = 'B';
                        }

                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow++;
                            matrix[beeRow, beeCol] = 'B';
                        }
                    }

                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[beeRow, beeCol] = '.';
                        //PrintMatrix(size, matrix);
                        break;
                    }
                }

                command = Console.ReadLine();
            }

            if (polinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }

            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
            }

            PrintMatrix(size, matrix);


        }

        private static void PrintMatrix(int size, char[,] matrix)
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

        private static bool CellValid(int beeCol, int beeRow, int size)
        {
            return beeCol >= 0 && beeCol < size && beeRow >= 0 && beeRow < size;
        }
    }
}

