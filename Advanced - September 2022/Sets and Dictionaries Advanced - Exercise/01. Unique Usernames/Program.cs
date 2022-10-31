using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join("\n", usernames));
        }
    }
}
