using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < numbersOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string currNaName = command[0];


                if (guests.Contains(currNaName) && command[2] == "going!")
                {
                    Console.WriteLine($"{command[0]} is already in the list!");
                }

                else if (guests.Contains(currNaName) && command[2] == "not")
                {
                    guests.Remove(command[0]);
                }

                else if (!guests.Contains(currNaName) && command[2] == "not")
                {
                    Console.WriteLine($"{command[0]} is not in the list!");
                }

                else
                {
                    guests.Add(command[0]);
                }
            }

            foreach (var name in guests)
            {
                Console.WriteLine(name);
            }
        }



    }
}
