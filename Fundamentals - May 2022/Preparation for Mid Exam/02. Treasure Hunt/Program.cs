using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> InitialLoot = Console.ReadLine().Split("|").ToList();
            string command = Console.ReadLine();

            while (command != "Yohoho!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Loot")
                {
                    int itemsCount = tokens.Length - 1;

                    for (int i = 1; i <= itemsCount; i++)
                    {
                        string item = tokens[i];

                        if (!InitialLoot.Contains(item))
                        {
                            InitialLoot.Insert(0, item);
                        }
                    }
                }

                else if (action == "Drop")
                {
                    int index = int.Parse(tokens[1]);

                    if (index >= 0 && index < InitialLoot.Count)
                    {
                        string itemToRemove = InitialLoot[index];
                        InitialLoot.Add(itemToRemove);
                        InitialLoot.Remove(itemToRemove);
                    }
                }

                else if (action == "Steal")
                {
                    int count = int.Parse(tokens[1]);

                    if (count < InitialLoot.Count)
                    {
                        List<string> stolenItems = new List<string>();

                        for (int i = 0; i < count; i++)
                        {

                            stolenItems.Add(InitialLoot[InitialLoot.Count - count + i]);
                            InitialLoot.RemoveAt(InitialLoot.Count - count + i);
                        }

                        Console.WriteLine(string.Join(", ", stolenItems));
                    }

                    else if (count >= InitialLoot.Count ;                      
                    {

                        List<string> stolenItems = new List<string>();

                        for (int i = 0; i < InitialLoot.Count; i++)
                        {
                            stolenItems.Add(InitialLoot[i]);
                            InitialLoot.RemoveAt(i);
                            i--;
                        }

                        Console.WriteLine(string.Join(", ", stolenItems));
                    }
                }

                command = Console.ReadLine();
            }

            if (InitialLoot.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }

            else
            {
                double average = 0;
                double sum = 0;

                for (int i = 0; i < InitialLoot.Count; i++)
                {
                    sum += InitialLoot[i].Length;
                }

                average = sum / InitialLoot.Count;

                Console.WriteLine($"Average treasure gain: {average:f2} pirate credits.");
            }
        }
    }
}
