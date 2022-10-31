using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    int numberToAdd = int.Parse(tokens[1]);
                    input.Add(numberToAdd);
                }

                else if (tokens[0] == "Remove")
                {
                   
                    int indexToRemoveAt = int.Parse(tokens[1]);

                    if (indexToRemoveAt <0 || indexToRemoveAt >=input .Count )
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }

                    else
                    {
                        input.RemoveAt(indexToRemoveAt);
                    }
                   
                }

                else if (tokens[0] == "Insert")
                {
                    int numberToInsert = int.Parse(tokens[1]);
                    int indexToInsertAt = int.Parse(tokens[2]);

                    if (indexToInsertAt < 0 || indexToInsertAt >= input.Count)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }

                    else
                    {
                        input.Insert(indexToInsertAt, numberToInsert);
                    }
                    
                }

                else if (tokens[0] == "Shift")
                {
                    int count = int.Parse(tokens[2]);

                    if (tokens[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            input.Add(input[0]);
                            input.RemoveAt(0);
                        }
                    }

                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            input.Insert(0, input[input.Count - 1]);
                            input.RemoveAt(input.Count - 1);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", input));

        }
    }
}
