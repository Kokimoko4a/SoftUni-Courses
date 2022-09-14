using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < numbers.Count; i++)
            {
                int currNumber = numbers.Dequeue();

                if (currNumber % 2 != 0)
                {
                    i--;
                }

                else
                {
                    numbers.Enqueue(currNumber);
                }
            }

            Console.WriteLine(String.Join(", ",numbers));

        }

    }
}
