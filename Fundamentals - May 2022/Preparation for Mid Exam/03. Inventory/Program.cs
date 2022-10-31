using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> startingItems = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries ).ToList();
            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] tokens = command.Split(" - ",StringSplitOptions.RemoveEmptyEntries );
                string action = tokens[0];
               

                if (action == "Collect")
                {
                    string item = tokens[1];

                    if (!startingItems.Contains(item))
                    {
                        startingItems.Add(item);
                    }                
                }

                else if (action == "Drop")
                {
                    string item = tokens[1];

                    if (startingItems.Contains (item ))
                    {
                        startingItems.Remove(item);
                    }
                }

                else if (action == "Combine Items")
                {
                    string[] combinators = tokens[1].Split (":");
                    string oldItem = combinators[0];
                    string newItem = combinators[1];

                    int index = 0;

                    if (startingItems .Contains (oldItem ))
                    {
                        for (int i = 0; i < startingItems .Count ; i++)
                        {
                            if (startingItems[i] == oldItem )
                            {
                                index = i;
                                break;
                            }
                        }

                        startingItems.Insert(index + 1, newItem);
                    }

                    
                }

                else if (action == "Renew")
                {
                    string item = tokens[1];

                    for (int i = 0; i < startingItems .Count ; i++)
                    {
                        if ( startingItems[i] == item)
                        {
                            startingItems.Add(item);
                           
                            break;
                        }
                    }

                    for (int i = 0; i < startingItems .Count ; i++)
                    {
                        if (startingItems[i] == item)
                        {
                            startingItems .RemoveAt(i );

                            break;
                        }
                    }

                }


                command = Console.ReadLine();
            }

            Console.WriteLine(string .Join (", ", startingItems ));

        }
    }
}
