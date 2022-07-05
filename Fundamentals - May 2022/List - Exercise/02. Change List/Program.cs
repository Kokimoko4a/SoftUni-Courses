using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Delete")
                {
                    int numberToRemove = int.Parse(tokens[1]);
                    input.RemoveAll(n => n == numberToRemove);

                }

                else
                {
                    int numbersToInsert = int.Parse(tokens[1]);
                    int position = int.Parse(tokens[2]);
                    input.Insert(position, numbersToInsert);

                }

                 command = Console.ReadLine();
            }

            Console.WriteLine(string.Join (" ",input ));
        }
    }
}
