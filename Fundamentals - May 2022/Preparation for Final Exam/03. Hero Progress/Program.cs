using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Progress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<HeroAttacks>> heroesInfo = new Dictionary<string, List<HeroAttacks>>();
            string command = Console.ReadLine();

            while (command != "Fight")
            {
                string[] tokens = command.Split(" -> ");
                string currHeroName = tokens[0];

                if (tokens.Length > 1)
                {
                    string currAttackName = tokens[1];
                    int currDamage = int.Parse(tokens[2]);
                    HeroAttacks currHeroStats = new HeroAttacks(currAttackName, currDamage);

                    if (!heroesInfo.ContainsKey(currHeroName))
                    {
                        heroesInfo.Add(currHeroName, new List<HeroAttacks>());
                        heroesInfo[currHeroName].Add(currHeroStats);
                    }

                    else
                    {
                        heroesInfo[currHeroName].Add(currHeroStats);
                    }
                }

                else if (tokens.Length == 1)
                {
                    /*^ { heroName}
                    { attackType} <> { damage}
                    { attackType} <> { damage}*/

                    if (heroesInfo.ContainsKey(currHeroName))
                    {
                        Console.WriteLine($"^ {currHeroName}");

                        foreach (var attack in heroesInfo[currHeroName])
                        {
                            Console.WriteLine($"{attack.Attack} <> {attack.Damage}");
                        }
                    }

                }

                command = Console.ReadLine();
            }

            foreach (var hero in heroesInfo)
            {
                Console.WriteLine($"^ {hero.Key}");

                foreach (var attack in hero.Value.OrderByDescending(x => x.Damage))
                {
                    Console.WriteLine($"{attack.Attack} <> {attack.Damage}");
                }
            }
        }
    }

    class HeroAttacks
    {
        public HeroAttacks(string attack, int damage)
        {
            Attack = attack;
            Damage = damage;
        }

        public string Attack { get; set; }
        public int Damage { get; set; }

    }
}
