using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join("\n",names));
        }
    }
}
