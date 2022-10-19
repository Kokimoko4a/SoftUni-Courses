using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    class Coordinates
    {
        public int Col { get; set; }
        public int Row { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            string input = Console.ReadLine();
            string[] attackCoordinates = input.Split(",");
            Queue<Coordinates> firstPlayer = new Queue<Coordinates>();
            Queue<Coordinates> secondPlayer = new Queue<Coordinates>();
            int countOfSecond = 0;
            int countOfFirst = 0;
            int countOfShips = 0;


            for (int i = 0; i < attackCoordinates.Length; i++)
            {
                int curr = int.Parse(attackCoordinates[i].Split().First());
                int curr2 = int.Parse(attackCoordinates[i].Split().Skip(1).First());

                if (curr >= 0 && curr < size && curr2 >= 0 && curr2 < size)
                {
                    Coordinates currCors = new Coordinates();
                    currCors.Row = curr;
                    currCors.Col = curr2;

                    if (i % 2 == 0)
                    {
                        firstPlayer.Enqueue(currCors);
                    }

                    else
                    {
                        secondPlayer.Enqueue(currCors);
                    }
                }
            }

            for (int row = 0; row < size; row++)
            {
                char[] currEle = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currEle[col];

                    if (matrix[row, col] == '>')
                    {
                        countOfSecond++;

                    }

                    else if (matrix[row, col] == '<')
                    {
                        countOfFirst++;

                    }
                }
            }

            int turn = 0;

            while (firstPlayer.Count > 0 || secondPlayer.Count > 0)
            {
                if (turn % 2 == 0)
                {
                    if (firstPlayer.Count > 0)
                    {
                        Coordinates coordinates = firstPlayer.Dequeue();
                        int row = coordinates.Row;
                        int col = coordinates.Col;

                        if (matrix[row, col] == '>')
                        {
                            matrix[row, col] = 'X';
                            countOfSecond--;
                            countOfShips++;
                            if (countOfSecond == 0)
                            {
                                Console.WriteLine($"Player One has won the game! {countOfShips} ships have been sunk in the battle.");
                                return;
                            }
                        }

                        else if (matrix[row, col] == '#')
                        {
                            matrix[row, col] = 'X';

                            if (row + 1 < size)
                            {
                                if (matrix[row + 1, col] == '>')
                                {
                                    countOfShips++;
                                    countOfSecond--;
                                    matrix[row + 1, col] = 'X';
                                    if (countOfSecond == 0)
                                    {
                                        Console.WriteLine($"Player One has won the game! {countOfShips} ships have been sunk in the battle.");
                                        return;
                                    }
                                }

                                if (matrix[row + 1, col] == '<')
                                {
                                    countOfShips++;
                                }

                                matrix[row + 1, col] = 'X';
                            }

                            if (row + 1 < size && col + 1 < size)
                            {
                                if (matrix[row + 1, col + 1] == '>')
                                {
                                    countOfShips++;
                                    countOfSecond--;
                                    matrix[row + 1, col + 1] = 'X';
                                    if (countOfSecond == 0)
                                    {
                                        Console.WriteLine($"Player One has won the game! {countOfShips} ships have been sunk in the battle.");
                                        return;
                                    }
                                }

                                if (matrix[row + 1, col + 1] == '<')
                                {
                                    countOfShips++;
                                }

                                matrix[row + 1, col + 1] = 'X';
                            }

                            if (col + 1 < size)
                            {
                                if (matrix[row, col + 1] == '>')
                                {
                                    countOfShips++;
                                    countOfSecond--;
                                    matrix[row, col + 1] = 'X';
                                    if (countOfSecond == 0)
                                    {
                                        Console.WriteLine($"Player One has won the game! {countOfShips} ships have been sunk in the battle.");
                                        return;
                                    }


                                }

                                if (matrix[row, col + 1] == '<')
                                {
                                    countOfShips++;
                                }

                                matrix[row, col + 1] = 'X';
                            }
                        }
                    }
                }

                else
                {
                    if (secondPlayer.Count > 0)
                    {



                        Coordinates coordinates = secondPlayer.Dequeue();
                        int row = coordinates.Row;
                        int col = coordinates.Col;

                        if (matrix[row, col] == '<')
                        {
                            countOfShips++;
                            matrix[row, col] = 'X';
                            countOfFirst--;

                            if (countOfFirst == 0)
                            {
                                Console.WriteLine($"Player Two has won the game! {countOfShips} ships have been sunk in the battle.");
                                return;
                            }
                        }

                        else if (matrix[row, col] == '#')
                        {
                            matrix[row, col] = 'X';

                            if (row + 1 < size)
                            {
                                if (matrix[row + 1, col] == '<')
                                {
                                    countOfShips++;
                                    countOfFirst--;
                                    matrix[row + 1, col] = 'X';
                                    if (countOfFirst == 0)
                                    {
                                        Console.WriteLine($"Player Two has won the game! {countOfShips} ships have been sunk in the battle.");
                                        return;
                                    }
                                }

                                if (matrix[row + 1, col] == '>')
                                {
                                    countOfShips++;
                                }

                                matrix[row + 1, col] = 'X';
                            }

                            if (row + 1 < size && col + 1 < size)
                            {
                                if (matrix[row + 1, col + 1] == '<')
                                {
                                    countOfShips++;
                                    countOfFirst--;
                                    matrix[row + 1, col + 1] = 'X';
                                    if (countOfFirst == 0)
                                    {
                                        Console.WriteLine($"Player Two has won the game! {countOfShips} ships have been sunk in the battle.");
                                        return;
                                    }
                                }

                                if (matrix[row + 1, col + 1] == '>')
                                {
                                    countOfShips++;
                                }

                                matrix[row + 1, col + 1] = 'X';
                            }

                            if (col + 1 < size)
                            {
                                if (matrix[row, col + 1] == '<')
                                {
                                    countOfShips++;
                                    countOfFirst--;
                                    matrix[row, col + 1] = 'X';
                                    if (countOfFirst == 0)
                                    {
                                        Console.WriteLine($"Player Two has won the game! {countOfShips} ships have been sunk in the battle.");
                                        return;
                                    }
                                }

                                if (matrix[row, col + 1] == '>')
                                {
                                    countOfShips++;
                                }

                                matrix[row, col + 1] = 'X';
                            }
                        }
                    }
                }

                turn++;
            }

            Console.WriteLine($"It's a draw! Player One has {countOfFirst} ships left. Player Two has {countOfSecond} ships left.");
        }
    }
}
