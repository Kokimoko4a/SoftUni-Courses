using System;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int gold = 0;
            int officerRow = 0;
            int officerCol = 0;
           

            for (int row = 0; row < size; row++)
            {
                string currElements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currElements[col];

                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (gold < 65)
            {
                if (command == "right")
                {
                    if (CellValid(officerCol + 1, officerRow, size))
                    {
                        char theElement = matrix[officerRow, officerCol + 1];

                        if (theElement == '-')
                        {
                            matrix[officerRow, officerCol] = '-';
                            officerCol++;
                            matrix[officerRow, officerCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow, officerCol + 1] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        officerRow = row;
                                        officerCol = col;
                                        matrix[officerRow, officerCol] = 'A';
                                        break;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            gold += int.Parse(theElement.ToString());
                            matrix[officerRow, officerCol] = '-';
                            officerCol++;
                            matrix[officerRow, officerCol] = 'A';


                        }
                    }

                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {gold} gold coins.");
                        matrix[officerRow, officerCol] = '-';
                        PrintMatrix(matrix, size);
                        return;
                    }
                }

                else if (command == "left")
                {
                    if (CellValid(officerCol - 1, officerRow, size))
                    {
                        char theElement = matrix[officerRow, officerCol - 1];

                        if (theElement == '-')
                        {
                            matrix[officerRow, officerCol] = '-';
                            officerCol--;
                            matrix[officerRow, officerCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow, officerCol - 1] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        officerRow = row;
                                        officerCol = col;
                                        matrix[officerRow, officerCol] = 'A';
                                        break;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            gold += int.Parse(theElement.ToString());
                            matrix[officerRow, officerCol] = '-';
                            officerCol--;
                            matrix[officerRow, officerCol] = 'A';
                        }
                    }

                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {gold} gold coins.");
                        matrix[officerRow, officerCol] = '-';
                        PrintMatrix(matrix, size);
                        return;
                    }
                }

                else if (command == "up")
                {
                    if (CellValid(officerCol, officerRow - 1, size))
                    {
                        char theElement = matrix[officerRow - 1, officerCol];

                        if (theElement == '-')
                        {
                            matrix[officerRow, officerCol] = '-';
                            officerRow--;
                            matrix[officerRow, officerCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow - 1, officerCol] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        officerRow = row;
                                        officerCol = col;
                                        matrix[officerRow, officerCol] = 'A';
                                        break;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            gold += int.Parse(theElement.ToString());
                            matrix[officerRow, officerCol] = '-';
                            officerRow--;
                            matrix[officerRow, officerCol] = 'A';


                        }
                    }

                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {gold} gold coins.");
                        matrix[officerRow, officerCol] = '-';
                        PrintMatrix(matrix, size);
                        return;
                    }


                }


                else if (command == "down")
                {
                    if (CellValid(officerCol, officerRow + 1, size))
                    {
                        char theElement = matrix[officerRow + 1, officerCol];

                        if (theElement == '-')
                        {
                            matrix[officerRow, officerCol] = '-';
                            officerRow++;
                            matrix[officerRow, officerCol] = 'A';
                        }

                        else if (theElement == 'M')
                        {
                            matrix[officerRow, officerCol] = '-';
                            matrix[officerRow + 1, officerCol] = '-';

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'M')
                                    {
                                        officerRow = row;
                                        officerCol = col;
                                        matrix[officerRow, officerCol] = 'A';
                                        break;
                                    }
                                }
                            }
                        }

                        else if (char.IsDigit(theElement))
                        {
                            gold += int.Parse(theElement.ToString());
                            matrix[officerRow, officerCol] = '-';
                            officerRow++;
                            matrix[officerRow, officerCol] = 'A';


                        }
                    }

                    else
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {gold} gold coins.");
                        matrix[officerRow, officerCol] = '-';
                        PrintMatrix(matrix, size);
                        return;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {gold} gold coins.");
            PrintMatrix(matrix, size);

            static void PrintMatrix(char[,] matrix, int size)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int h = 0; h < size; h++)
                    {
                        Console.Write(matrix[i, h]);
                    }

                    Console.WriteLine();
                }
            }

            static bool CellValid(int officerCol, int officerRow, int size)
            {
                return officerCol >= 0 && officerRow >= 0 && officerCol < size && officerRow < size;
            }


        }
    }
}
