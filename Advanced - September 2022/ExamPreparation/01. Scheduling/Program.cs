using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int wantedTask = int.Parse(Console.ReadLine());
            int thread = 0;

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int task = tasks.Peek();
                thread = threads.Peek();

                if (task == wantedTask)
                {
                    break;
                }

                else if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }

                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {thread} killed task {wantedTask}");
            Console.WriteLine(string.Join(" ", threads));

        }
    }
}
