using System;
using System.Collections;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>(Console.ReadLine().Split());

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, people));
                    people.Clear();
                }

                else
                {
                    people.Enqueue(tokens[0]);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
