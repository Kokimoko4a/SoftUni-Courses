using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> positions = new Stack<int>();
            string input = Console.ReadLine();

            for (int i = 0; i < input .Length; i++)
            {
                if (input[i] == '(' )
                {
                    positions.Push(i);
                }

                else if (input[i] == ')' )
                {
                    Console.WriteLine(input .Substring (positions .Peek () , i-positions .Pop ()+1));
                }
            }
        }
    }
}
