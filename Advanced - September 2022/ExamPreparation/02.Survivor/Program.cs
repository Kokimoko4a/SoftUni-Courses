using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] jagged = new char[size][];
            int myTokens = 0;
            int opponentTokens = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currEle = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                jagged[row] = new char[currEle.Length];

                for (int col = 0; col < currEle.Length; col++)
                {                  
                    jagged[row][col] = currEle[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "Gong")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (action == "Find")
                {


                    if (CoordinatesValid(row, col, size, jagged))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            myTokens++;
                            jagged[row][col] = '-';
                        }
                    }
                }

                else if (action == "Opponent")
                {
                    string direction = tokens[3];

                    if (direction == "left")
                    {
                        if (CoordinatesValid(row, col, size, jagged))
                        {
                            if (jagged[row][col] == 'T')
                            {
                                opponentTokens++;
                                jagged[row][col] = '-';
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                col--;

                                if (col >= 0 && col < jagged[row].Length)
                                {
                                    if (jagged[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jagged[row][col] = '-';
                                    }

                                }
                            }
                        }                                                         
                    }

                    else if (direction == "right")
                    {
                        if (CoordinatesValid(row, col, size, jagged))
                        {
                            if (jagged[row][col] == 'T')
                            {
                                opponentTokens++;
                                jagged[row][col] = '-';
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                col++;

                                if (col >= 0 && col < jagged[row].Length)
                                {
                                    if (jagged[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jagged[row][col] = '-';
                                    }

                                }
                            }
                        }
                    }

                    else if (direction == "down")
                    { 
                        if (CoordinatesValid(row, col, size, jagged))
                        {
                            if (jagged[row][col] == 'T')
                            {
                                opponentTokens++;
                                jagged[row][col] = '-';
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                row++;

                                if (row >= 0 && row < size)
                                {
                                    if (jagged[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jagged[row][col] = '-';
                                    }

                                }
                            }
                        }
                    }

                    else if (direction == "up")
                    {
                        if (CoordinatesValid(row, col, size, jagged))
                        {
                            if (jagged[row][col] == 'T')
                            {
                                opponentTokens++;
                                jagged[row][col] = '-';
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                row--;

                                if (row >= 0 && row < size)
                                {
                                    if (jagged[row][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jagged[row][col] = '-';
                                    }

                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            PrintMatrix(jagged, size);

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");




        }

        static bool CoordinatesValid(int row, int col, int size, char[][] jagged )
        {
            if (row>=0 && row<size)
            {
                return row >= 0 && col >= 0 && col < jagged[row].Length && row < size;
            }

            return false;
          
        }
         static void PrintMatrix(char[][] jagged, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < jagged[i].Length; k++)
                {
                    Console.Write(jagged[i][k] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
