using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ',',' '}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();
            Stack<string> stack = new Stack<string>(input);

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split();

                if (command == "Pop")
                {
                    try
                    {
                        //Console.WriteLine(stack.Pop());
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                else if (tokens[0] == "Push")
                {
                    

                    stack.Push(tokens.Skip(1).ToArray());
                }

                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

