using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> expressions = new Stack<string>(input.Reverse());

            int result = int.Parse(expressions.Pop());

            while (expressions.Count>0)
            {
                if (expressions.Pop() == "+")
                {
                    result += int.Parse(expressions.Pop());
                }

                else
                {
                    result -= int.Parse(expressions.Pop());
                }
            }

            

            Console.WriteLine(result);

        }
    }
}
