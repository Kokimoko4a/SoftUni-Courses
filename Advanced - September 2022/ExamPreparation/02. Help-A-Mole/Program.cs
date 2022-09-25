using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int points = 0;
            int rowOfMole = 0;
            int colOfMole = 0;

            for (int row = 0; row < size; row++)
            {
                string currElements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currElements[col];

                    if (matrix[row, col] == 'M')
                    {
                        rowOfMole = row;
                        colOfMole = col;

                    }
                }
            }

            string command = Console.ReadLine();

            while (points < 25)
            {
                if (command == "End")
                {
                    break;
                }

                if (command == "left")
                {
                    if (IsCellValid(matrix, rowOfMole, colOfMole - 1, size))
                    {
                        char currElement = matrix[rowOfMole, colOfMole - 1];

                        if (char.IsDigit(currElement))
                        {
                            points += int.Parse(currElement.ToString());
                            matrix[rowOfMole, colOfMole - 1] = 'M';
                            matrix[rowOfMole, colOfMole] = '-';
                            colOfMole--;


                            command = Console.ReadLine();
                            continue;
                        }

                        if (currElement == 'S')
                        {
                            matrix[rowOfMole, colOfMole - 1] = '-';
                            matrix[rowOfMole, colOfMole] = '-';
                            points -= 3;

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'S')
                                    {
                                        rowOfMole = row;
                                        colOfMole = col;

                                        matrix[rowOfMole, colOfMole] = 'M';
                                    }
                                }
                            }

                        }

                        else
                        {
                            matrix[rowOfMole, colOfMole] = '-';
                            matrix[rowOfMole, colOfMole - 1] = 'M';
                            colOfMole--;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }


                else if (command == "right")
                {
                    if (IsCellValid(matrix, rowOfMole, colOfMole + 1, size))
                    {
                        char currElement = matrix[rowOfMole, colOfMole + 1];

                        if (char.IsDigit(currElement))
                        {
                            points += int.Parse(currElement.ToString());
                            matrix[rowOfMole, colOfMole + 1] = 'M';
                            matrix[rowOfMole, colOfMole] = '-';
                            colOfMole++;
                            command = Console.ReadLine();
                            continue;

                        }

                        if (currElement == 'S')
                        {
                            matrix[rowOfMole, colOfMole + 1] = '-';
                            matrix[rowOfMole, colOfMole] = '-';
                            points -= 3;

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'S')
                                    {
                                        rowOfMole = row;
                                        colOfMole = col;

                                        matrix[rowOfMole, colOfMole] = 'M';
                                    }
                                }
                            }

                        }

                        else
                        {
                            matrix[rowOfMole, colOfMole] = '-';
                            matrix[rowOfMole, colOfMole + 1] = 'M';
                            colOfMole++;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }

                else if (command == "up")
                {
                    if (IsCellValid(matrix, rowOfMole - 1, colOfMole, size))
                    {
                        char currElement = matrix[rowOfMole - 1, colOfMole];

                        if (char.IsDigit(currElement))
                        {
                            points += int.Parse(currElement.ToString());
                            matrix[rowOfMole - 1, colOfMole] = 'M';
                            matrix[rowOfMole, colOfMole] = '-';
                            rowOfMole--;
                            command = Console.ReadLine();
                            continue;

                        }

                        if (currElement == 'S')
                        {
                            matrix[rowOfMole - 1, colOfMole] = '-';
                            matrix[rowOfMole, colOfMole] = '-';
                            points -= 3;

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'S')
                                    {
                                        rowOfMole = row;
                                        colOfMole = col;

                                        matrix[rowOfMole, colOfMole] = 'M';
                                    }
                                }
                            }

                        }

                        else
                        {
                            matrix[rowOfMole, colOfMole] = '-';
                            matrix[rowOfMole - 1, colOfMole] = 'M';
                            rowOfMole--;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }

                else if (command == "down")
                {
                    if (IsCellValid(matrix, rowOfMole + 1, colOfMole, size))
                    {
                        char currElement = matrix[rowOfMole + 1, colOfMole];

                        if (char.IsDigit(currElement))
                        {
                            points += int.Parse(currElement.ToString());
                            matrix[rowOfMole + 1, colOfMole] = 'M';
                            matrix[rowOfMole, colOfMole] = '-';
                            rowOfMole++;
                            command = Console.ReadLine();
                            continue;

                        }

                        if (currElement == 'S')
                        {
                            matrix[rowOfMole + 1, colOfMole] = '-';
                            matrix[rowOfMole, colOfMole] = '-';
                            points -= 3;

                            for (int row = 0; row < size; row++)
                            {
                                for (int col = 0; col < size; col++)
                                {
                                    if (matrix[row, col] == 'S')
                                    {
                                        rowOfMole = row;
                                        colOfMole = col;

                                        matrix[rowOfMole, colOfMole] = 'M';
                                    }
                                }
                            }

                        }

                        else
                        {
                            matrix[rowOfMole, colOfMole] = '-';
                            matrix[rowOfMole + 1, colOfMole] = 'M';
                            rowOfMole++;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }

                command = Console.ReadLine();
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }

            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int row = 0; row < size; row++)
            {


                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsCellValid(char[,] matrix, int rowOfmole, int colOfmole, int size)
        {
            return rowOfmole >= 0 && rowOfmole < size && colOfmole >= 0 && colOfmole < size;
        }
    }
}

