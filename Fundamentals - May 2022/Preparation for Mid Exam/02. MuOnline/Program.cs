using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine().Split('|').ToList();
            int initialHealth = 100;
            int initialBitCoins = 0;
            // int copyOfHealth = 100;
            bool isDied = false;
            // int bestRoom = 0;


            for (int i = 0; i < rooms.Count; i++)
            {
                string[] commands = rooms[i].Split();
                string action = commands[0];
                int amount = int.Parse(commands[1]);

                switch (action)
                {
                    case "potion":
                        if (initialHealth + amount <= 100)
                        {
                            initialHealth += amount;
                            Console.WriteLine($"You healed for {amount} hp.");
                            Console.WriteLine($"Current health: {initialHealth} hp.");
                        }

                        else
                        {
                            int j = 0;
                            for (j = 0; j < amount; j++)
                            {
                                if (initialHealth + 1 > 100)
                                {
                                    break;
                                }
                                initialHealth += 1;
                            }

                            Console.WriteLine($"You healed for {j} hp.");
                            Console.WriteLine($"Current health: {initialHealth} hp.");
                        }
                        break;

                    case "chest":
                        initialBitCoins += amount;
                        Console.WriteLine($"You found {amount} bitcoins.");
                        break;

                    default:
                        if (initialHealth - amount > 0)
                        {
                            Console.WriteLine($"You slayed {action}.");
                            initialHealth -= amount;
                        }

                        else
                        {
                            isDied = true;
                            Console.WriteLine($"You died! Killed by {action}.");
                            Console.WriteLine($"Best room: {i + 1}");
                        }

                        break;
                }

                if (isDied)
                {
                    return;
                }
            }


            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {initialBitCoins}");
            Console.WriteLine($"Health: {initialHealth}");




        }
    }
}
