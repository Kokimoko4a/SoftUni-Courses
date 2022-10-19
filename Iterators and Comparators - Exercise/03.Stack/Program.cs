using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();
            Stack<string> stack = new Stack<string>(input);

            string command = Console.ReadLine();

            while (command != "END")
            {
                 if (command == "Pop")
                {
                    try
                    {
                        Console.WriteLine(stack.Pop());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if (command == "Push")
                {
                    string[] tokens = command.Split().Skip(1).ToArray();

                    stack.Push(tokens);
                }

                command = Console.ReadLine();
            }
        }
    }
}

