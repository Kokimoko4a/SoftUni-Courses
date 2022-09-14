using System;
using System.Collections;
using System.Collections.Generic;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> stack = new Queue<string>(Console.ReadLine().Split());
            Console.WriteLine(stack.Dequeue());
        }
    }
}
