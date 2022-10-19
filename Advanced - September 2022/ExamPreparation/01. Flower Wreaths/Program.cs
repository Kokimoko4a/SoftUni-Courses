using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int countOfWreaths = 0;
            int flowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lili = lilies.Peek();
                int rose = roses.Peek();
                int sum = lili + rose;

                if (sum == 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    countOfWreaths++;
                }

                else if (sum > 15)
                {
                    lili -= 2;

                    while (true)
                    {
                        if (lili + rose == 15)
                        {
                            lilies.Pop();
                            roses.Dequeue();
                            countOfWreaths++;
                            break;
                        }

                        else if (lili + rose < 15)
                        {
                            lilies.Pop();
                            roses.Dequeue();
                            flowers += lili + rose;
                            break;
                        }

                        lili -= 2;
                    }
                }

                else if (sum < 15)
                {
                    flowers += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            countOfWreaths += flowers / 15;

            string output = countOfWreaths >= 5 ? $"You made it, you are going to the competition with {countOfWreaths} wreaths!" : $"You didn't make it, you need {5 - countOfWreaths} wreaths more!";
            Console.WriteLine(output);

        }
    }
}
