﻿using System;
using System.Linq;

namespace _02.Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            ListyIterator<string> list = new ListyIterator<string>(input);

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (Exception exepction)
                    {
                        Console.WriteLine(exepction.Message);

                    }
                }

                else if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }

                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }

                else if (command == "PrintAll")
                {
                    foreach (var item in list)
                    {
                        Console.Write(item + " ");
                    }

                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }
    }
}

