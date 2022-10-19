using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int beaverRow = -1;
            int beaverCol = -1;
            Stack<char> branches = new Stack<char>();
            int countOfBranches = 0;

            for (int row = 0; row < size; row++)
            {
                char[] curr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = curr[col];

                    if (matrix[row, col] == 'B')
                    {
                        beaverCol = col;
                        beaverRow = row;
                    }

                    else if (char.IsLower(matrix[row, col]))
                    {
                        countOfBranches++;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "right")
                {
                    if (CellValid(beaverRow, beaverCol + 1, size))
                    {
                        char futureElement = matrix[beaverRow, beaverCol + 1];

                        if (futureElement !='F' && !char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            beaverCol++;
                            matrix[beaverRow, beaverCol] = 'B';
                        }

                        else if (char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            branches.Push(futureElement);
                            beaverCol++;

                            matrix[beaverRow, beaverCol] = 'B';

                            countOfBranches--;
                            if (countOfBranches == 0)
                            {
                                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                PrintMatrix(matrix, size);
                                return;
                            }
                        }

                        else if (futureElement == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            matrix[beaverRow, beaverCol+1] = '-';

                            if (beaverCol + 1 == size - 1)
                            {
                               
                                beaverCol = 0;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);

                                    matrix[beaverRow, beaverCol] = 'B';

                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }

                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }

                            else
                            {
                               
                                beaverCol = size - 1;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);

                                    matrix[beaverRow, beaverCol] = 'B';

                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                    }

                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }

                else if (command == "left")
                {
                    if (CellValid(beaverRow, beaverCol - 1, size))
                    {
                        char futureElement = matrix[beaverRow, beaverCol - 1];

                        if (futureElement != 'F' && !char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            beaverCol--;
                            matrix[beaverRow, beaverCol] = 'B';
                        }

                        else if (char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            branches.Push(futureElement);
                            beaverCol--;
                            matrix[beaverRow, beaverCol] = 'B';


                            countOfBranches--;
                            if (countOfBranches == 0)
                            {
                                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                PrintMatrix(matrix, size);
                                return;
                            }

                        }

                        else if (futureElement == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            matrix[beaverRow, beaverCol-1] = '-';

                            if (beaverCol - 1 == 0)
                            {
                              
                                beaverCol = size - 1;
                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);

                                    matrix[beaverRow, beaverCol] = 'B';

                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }

                            else
                            {
                                beaverCol = 0;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);

                                    matrix[beaverRow, beaverCol] = 'B';
                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                    }

                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }

                else if (command == "down")
                {
                    if (CellValid(beaverRow + 1, beaverCol, size))
                    {
                        char futureElement = matrix[beaverRow + 1, beaverCol];

                        if (futureElement != 'F' && !char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            beaverRow++;
                            matrix[beaverRow, beaverCol] = 'B';

                        }

                        else if (char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            branches.Push(futureElement);
                            beaverRow++;
                            matrix[beaverRow, beaverCol] = 'B';

                            countOfBranches--;
                            if (countOfBranches == 0)
                            {
                                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                PrintMatrix(matrix, size);
                                return;
                            }
                        }

                        else if (futureElement == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            matrix[beaverRow + 1, beaverCol] = '-';

                            if (beaverRow + 1 == size - 1)
                            {
                               
                                beaverRow = 0;
                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);
                                    matrix[beaverRow, beaverCol] = 'B';
                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }

                            else
                            {
                               
                                beaverRow = size - 1;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);
                                    matrix[beaverRow, beaverCol] = 'B';
                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                    }

                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }

                else if (command == "up")
                {
                    if (CellValid(beaverRow - 1, beaverCol, size))
                    {
                        char futureElement = matrix[beaverRow - 1, beaverCol];

                        if (futureElement != 'F' && !char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            beaverRow--;
                            matrix[beaverRow, beaverCol] = 'B';

                        }

                        else if (char.IsLower(futureElement))
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            branches.Push(futureElement);
                            beaverRow--;
                            matrix[beaverRow, beaverCol] = 'B';

                            countOfBranches--;
                            if (countOfBranches == 0)
                            {
                                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                PrintMatrix(matrix, size);
                                return;
                            }
                        }

                        else if (futureElement == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            matrix[beaverRow - 1, beaverCol] = '-';

                            if (beaverRow - 1 == 0)
                            {
                               
                                beaverRow = size - 1;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);

                                    matrix[beaverRow, beaverCol] = 'B';

                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }
                                }

                                matrix[beaverRow, beaverCol] = 'B';
                            }

                            else
                            {
                                beaverRow = 0;

                                if (char.IsLower(matrix[beaverRow, beaverCol]))
                                {
                                    branches.Push(matrix[beaverRow, beaverCol]);

                                    matrix[beaverRow, beaverCol] = 'B';

                                    countOfBranches--;
                                    if (countOfBranches == 0)
                                    {
                                        Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
                                        PrintMatrix(matrix, size);
                                        return;
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                    }

                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }

                command = Console.ReadLine();
            }               
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfBranches} branches left.");
            


            PrintMatrix(matrix, size);

            static bool CellValid(int beaverRow, int beaverCol, int size)
            {
                return beaverCol < size && beaverRow >= 0 && beaverRow < size && beaverCol >= 0;
            }
        }

        private static void PrintMatrix(char[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int r = 0; r < size; r++)
                {
                    Console.Write(matrix[i, r] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

