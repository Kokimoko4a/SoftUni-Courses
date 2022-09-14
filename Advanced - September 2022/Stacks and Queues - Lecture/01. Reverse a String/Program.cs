using System;
using System.Collections.Generic;

namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
