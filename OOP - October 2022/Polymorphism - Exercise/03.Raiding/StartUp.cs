using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (countOfLines>0)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero baseHero = null;


                if (type == "Druid")
                {
                    baseHero = new Druid(name);
                }

                else if (type == "Paladin")
                {
                    baseHero = new Paladin(name);
                }

                else if (type == "Rogue")
                {
                    baseHero = new Rogue(name);
                }

                else if (type == "Warrior")
                {
                    baseHero = new Warrior(name);
                }

                if (baseHero!=null)
                {
                    heroes.Add(baseHero);
                    countOfLines--;
                }

                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var item in heroes)
            {
                bossPower -= item.Power;
                Console.WriteLine(item.CastAbility());
            }

            string result = bossPower <= 0 ? "Victory!" : "Defeat...";
            Console.WriteLine(result);

        }
    }
}
