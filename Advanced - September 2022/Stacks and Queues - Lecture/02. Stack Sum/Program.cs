using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string[] command = Console.ReadLine().ToLower().Split();

            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }

                else if (command[0] == "remove")
                {
                    int countToRemove = int.Parse(command[1]);

                    if (countToRemove <= numbers.Count)
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower().Split();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
