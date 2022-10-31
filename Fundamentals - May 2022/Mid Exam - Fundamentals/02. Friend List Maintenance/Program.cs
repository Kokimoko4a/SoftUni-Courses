using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Friend_List_Maintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> friendList = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();
            int blackListedNamescount = 0;
            int lostNamescount = 0;

            while (command != "Report")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Blacklist")
                {
                    string name = tokens[1];

                    if (friendList.Contains(name))
                    {
                        for (int i = 0; i < friendList.Count; i++)
                        {
                            if (friendList[i] == name)
                            {
                                Console.WriteLine($"{name} was blacklisted.");
                                friendList[i] = "Blacklisted";
                                blackListedNamescount++;
                                break;
                            }
                        }

                    }

                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }

                else if (action == "Error")
                {
                    int inexOfError = int.Parse(tokens[1]);

                    if (inexOfError < friendList.Count && inexOfError >= 0)
                    {
                        if (friendList[inexOfError] != "Blacklisted" && friendList[inexOfError] != "Lost")
                        {
                            Console.WriteLine($"{friendList[inexOfError]} was lost due to an error.");
                            friendList[inexOfError] = "Lost";
                            lostNamescount++;
                        }
                    }
                }

                else if (action == "Change")
                {
                    int indexToChangeAt = int.Parse(tokens[1]);
                    string newName = tokens[2];

                    if (indexToChangeAt < friendList.Count && indexToChangeAt >= 0)
                    {
                        Console.WriteLine($"{friendList[indexToChangeAt]} changed his username to {newName}.");
                        friendList[indexToChangeAt] = newName;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {blackListedNamescount}");
            Console.WriteLine($"Lost names: {lostNamescount}");
            Console.WriteLine(String.Join(" ", friendList));
        }
    }
}
