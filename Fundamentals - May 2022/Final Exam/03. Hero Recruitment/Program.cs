using System;
using System.Collections.Generic;

namespace _03._Hero_Recruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroesInfos = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] arguments = command.Split();
                string action = arguments[0];

                if (action == "Enroll")
                {
                    string currName = arguments[1];

                    if (!heroesInfos.ContainsKey(currName))
                    {
                        heroesInfos.Add(currName, new List<string>());
                    }

                    else
                    {
                        Console.WriteLine($"{currName} is already enrolled.");
                    }
                }

                else if (action == "Learn")
                {
                    string currName = arguments[1];
                    string currSpell = arguments[2];

                    if (heroesInfos.ContainsKey(currName))
                    {
                        if (!heroesInfos[currName].Contains(currSpell))
                        {
                            heroesInfos[currName].Add(currSpell);
                        }

                        else
                        {
                            Console.WriteLine($"{currName} has already learnt {currSpell}.");
                        }
                    }

                    else
                    {
                        Console.WriteLine($"{currName} doesn't exist.");
                    }
                }

                else if (action == "Unlearn")
                {
                    string currName = arguments[1];
                    string currSpell = arguments[2];

                    if (heroesInfos.ContainsKey(currName))
                    {
                        if (heroesInfos[currName].Contains(currSpell))
                        {
                            heroesInfos[currName].Remove(currSpell);
                        }

                        else
                        {
                            Console.WriteLine($"{currName} doesn't know {currSpell}.");
                        }
                    }

                    else
                    {
                        Console.WriteLine($"{currName} doesn't exist.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Heroes:");

            foreach (var hero in heroesInfos)
            {

                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }

        }
    }
}
