using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToEnqueue = elements[0];
            int elementsToDequeue = elements[1];
            int elementToSearchFor = elements[2];
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Enqueue(input[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count>0)
            {
                if (numbers.Contains(elementToSearchFor))
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }

            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
