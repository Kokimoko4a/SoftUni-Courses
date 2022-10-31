using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int stackNumbers = elements[0];
            int countOfNumbersToPop = elements[1];
            int numberToSearchFor = elements[2];
            Stack<int> stack = new Stack<int>();
            bool isFound = false;
            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(int.Parse(input[i]));
            }

            for (int i = 0; i < countOfNumbersToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count >= 1)
            {
                if (stack.Contains(numberToSearchFor))
                {
                    Console.WriteLine("true");
                    isFound = true;
                    return;
                }

                if (!isFound)
                {
                    Console.WriteLine(stack.Min());
                }
            }

            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
