using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));
            string command = Console.ReadLine();

            while (songs.Count>0)
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action== "Play")
                {
                    songs.Dequeue();
                }

                else if (action== "Add")
                {
                    string song = string.Join(" ",tokens.Skip(1));

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }

                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }

                else if (action == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
