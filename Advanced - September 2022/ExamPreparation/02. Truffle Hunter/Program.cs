using System;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int black = 0;
            int summer = 0;
            int white = 0;
            int boar = 0;

            for (int row = 0; row < size; row++)
            {
                char[] chars = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "Stop the hunt")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Collect")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);

                    if (CellValid(int.Parse(tokens[1]), int.Parse(tokens[2]), size))
                    {
                        if (matrix[row, col] == 'B')
                        {
                            matrix[row, col] = '-';
                            black++;
                        }

                        else if (matrix[row, col] == 'W')
                        {
                            matrix[row, col] = '-';
                            white++;
                        }

                        else if (matrix[row, col] == 'S')
                        {
                            matrix[row, col] = '-';
                            summer++;
                        }
                    }
                }

                else if (tokens[0] == "Wild_Boar")
                {
                    int row = int.Parse(tokens[1]);
                    int rowCopy = row;
                    int col = int.Parse(tokens[2]);
                    int colCopy = col;
                    string direction = tokens[3];

                    if (CellValid(row, col, size))
                    {
                        if (direction == "up")
                        {
                            if (CellValid(row-1, col, size))
                            {
                                bool canMove = true;
                                int i = 0;

                                while (canMove)
                                {
                                    if (matrix[rowCopy,colCopy] !='-' && i%2==0)
                                    {
                                        boar++;
                                        matrix[rowCopy,colCopy] = '-';
                                    }

                                    rowCopy--;
                                    i++;

                                    if (!CellValid(rowCopy, col, size))
                                    {
                                        canMove = false;
                                    }
                                   
                                }
                            }

                            else
                            {
                                if (matrix[row,col] !='-')
                                {
                                    boar++;
                                    matrix[rowCopy,colCopy] = '-';
                                }
                            }

                           
                        }

                        else if (direction == "down")
                        {
                            if (CellValid(row + 1, col, size))
                            {
                                bool canMove = true;
                                int i = 0;

                                while (canMove)
                                {
                                    if (matrix[rowCopy, colCopy] != '-' && i % 2 == 0)
                                    {
                                        boar++;
                                        matrix[rowCopy, colCopy] = '-';
                                    }

                                    rowCopy++;
                                    i++;

                                    if (!CellValid(rowCopy, col, size))
                                    {
                                        canMove = false;
                                    }

                                }
                            }

                            else
                            {
                                if (matrix[row, col] != '-')
                                {
                                    boar++;
                                    matrix[row, col] = '-';
                                }
                            }

                        }

                        else if (direction == "right")
                        {
                            if (CellValid(row, col+1, size))
                            {
                                bool canMove = true;
                                int i = 0;

                                while (canMove)
                                {
                                    if (matrix[rowCopy, colCopy] != '-' && i % 2 == 0)
                                    {
                                        boar++;
                                        matrix[rowCopy, colCopy] = '-';
                                    }

                                    colCopy++;
                                    i++;

                                    if (!CellValid(rowCopy, colCopy, size))
                                    {
                                        canMove = false;
                                    }

                                }
                            }

                            else
                            {
                                if (matrix[row, col] != '-')
                                {
                                    boar++;
                                    matrix[row, col] = '-';
                                }
                            }

                        }

                        else if (direction == "left")
                        {
                            if (CellValid(row, col - 1, size))
                            {
                                bool canMove = true;
                                int i = 0;

                                while (canMove)
                                {
                                    if (matrix[rowCopy, colCopy] != '-' && i % 2 == 0)
                                    {
                                        boar++;
                                        matrix[rowCopy,colCopy] = '-';
                                    }

                                    colCopy--;
                                    i++;

                                    if (!CellValid(rowCopy, colCopy, size))
                                    {
                                        canMove = false;
                                    }

                                }
                            }

                            else
                            {
                                if (matrix[row, col] != '-')
                                {
                                    boar++;
                                    matrix[row, col] = '-';
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boar} truffles.");

            for (int row = 0; row < size; row++)
            {
              

                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool CellValid(int row, int col, int size)
        {
            return row >= 0 && col >= 0 && row < size && col < size;
        }
    }
}
