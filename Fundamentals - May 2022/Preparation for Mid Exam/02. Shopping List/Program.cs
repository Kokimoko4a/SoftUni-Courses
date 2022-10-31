using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shopingList = Console.ReadLine().Split("!").ToList();
            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Urgent")
                {
                    string item = tokens[1];

                    if (!shopingList.Contains(item))
                    {
                        shopingList.Insert(0, item);
                    }
                }

                else if (action == "Unnecessary")
                {
                    string item = tokens[1];

                    if (shopingList.Contains(item))
                    {
                        shopingList.Remove(item);
                    }
                }

                else if (action == "Correct")
                {
                    string oldItem = tokens[1];
                    string newItem = tokens[2];

                    if (shopingList.Contains(oldItem))
                    {
                        for (int i = 0; i < shopingList.Count; i++)
                        {
                            if (shopingList[i] == oldItem)
                            {
                                shopingList[i] = newItem;
                                break;
                            }
                        }
                    }
                }

                else if (action == "Rearrange")
                {
                    string item = tokens[1];

                    if (shopingList.Contains(item))
                    {
                        shopingList.Remove(item);
                        shopingList.Add(item);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shopingList));
        }
    }
}
