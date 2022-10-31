using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double status = 0.2 * maxHealth;

            while (command != "Retire")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Fire")
                {
                    int index = int.Parse(tokens[1]);
                    int damage = int.Parse(tokens[2]);

                    if (index < warShip.Count && index >= 0)
                    {
                        warShip[index] -= damage;

                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }

                else if (action == "Defend")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    int damage = int.Parse(tokens[3]);

                    if (startIndex < pirateShip.Count && startIndex >= 0 &&  endIndex < pirateShip.Count && endIndex >= 0)
                           
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {

                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");

                                return;
                            }
                        }
                    }
                }


                else if (action == "Repair")
                {
                    int index = int.Parse(tokens[1]);
                    int health = int.Parse(tokens[2]);

                    if (index < warShip.Count && index >= 0)
                    {
                        for (int i = 1; i < health; i++)
                        {
                            if (pirateShip[index ]+i>100)
                            {
                                break;
                            }


                            pirateShip[index] += i;
                        }

                    }
                }

                else if (action == "Status")
                {
                    int count = 0;

                    for (int i = 0; i < count; i++)
                    {
                        if (pirateShip[i] > status)
                        {
                            count++;
                        }


                    }

                    Console.WriteLine($"{count} sections need repair.");


                }

                command = Console.ReadLine();

            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}
