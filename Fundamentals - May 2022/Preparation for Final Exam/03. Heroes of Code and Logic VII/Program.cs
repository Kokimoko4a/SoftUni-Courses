using System;
using System.Collections.Generic;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroesInfo = new Dictionary<string, Hero>();
            int countOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfHeroes; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int HP = int.Parse(tokens[1]);
                int MP = int.Parse((tokens[2]));
                Hero hero = new Hero(HP, MP);
                heroesInfo.Add(name, hero);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" - ");
                string action = tokens[0];

                if (action == "CastSpell")
                {
                    string heroName = tokens[1];
                    int MPneeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];

                    if (heroesInfo[heroName].MP >= MPneeded)
                    {
                        heroesInfo[heroName].MP -= MPneeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroesInfo[heroName].MP} MP!");
                    }

                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }

                }

                else if (action == "TakeDamage")
                {
                    string heroName = tokens[1];
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];

                    heroesInfo[heroName].HP -= damage;

                    if (heroesInfo[heroName].HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesInfo[heroName].HP} HP left!");
                    }

                    else 
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroesInfo.Remove(heroName);
                    }
                }

                else if (action == "Recharge")
                {
                    string heroName = tokens[1];
                    int amount = int.Parse(tokens[2]);
                    int konBobQdeLi = 200 - heroesInfo[heroName].MP;

                    if (heroesInfo[heroName].MP + amount <= 200)
                    {
                        heroesInfo[heroName].MP += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }

                    else
                    { 
                        heroesInfo[heroName].MP += konBobQdeLi;
                        Console.WriteLine($"{heroName} recharged for {konBobQdeLi} MP!");
                    }
                }

                else if (action == "Heal")
                {
                    string heroName = tokens[1];
                    int amount = int.Parse(tokens[2]);
                    int konBobQdeLi = 100 - heroesInfo[heroName].HP;

                    if (heroesInfo[heroName].HP + amount <= 100)
                    {
                        heroesInfo[heroName].HP += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }

                    else if (heroesInfo[heroName].HP + amount > 100)
                    {
                        heroesInfo[heroName].HP += konBobQdeLi;
                        Console.WriteLine($"{heroName} healed for {konBobQdeLi} HP!");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heroesInfo)
            {
                /*"{hero name}
                HP: { current HP}
                 MP: { current MP}*/

                Console.WriteLine(hero.Key);
                Console.WriteLine($" HP: {hero.Value.HP}");
                Console.WriteLine($" MP: {hero.Value.MP}");

            }
        }
    }

    class Hero
    {
        public Hero(int hP, int mP)
        {
            HP = hP;
            MP = mP;
        }

        public int HP { get; set; }
        public int MP { get; set; }
    }
}