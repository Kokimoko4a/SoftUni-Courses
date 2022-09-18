using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfQueries = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < countOfQueries; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int action = tokens[0];

                if (action == 1)
                {
                    int numberToPush = tokens[1];

                    numbers.Push(numberToPush);
                }

                else if (action == 2)
                {
                    if (numbers.Count >0)
                    {
                        numbers.Pop();
                    }                 
                }

                else if (action == 3)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }

                else if (action == 4)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            while (numbers.Count > 0)
            {
                if (numbers.Count > 1)
                {
                    Console.Write(numbers.Pop() + ", ");
                }

                else
                {
                    Console.WriteLine(numbers.Pop());
                }
            }
        }
    }
}
