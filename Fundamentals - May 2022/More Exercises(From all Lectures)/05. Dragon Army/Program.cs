using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfDDragons = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, DragondStats>> dragonsInfos = new Dictionary<string, Dictionary<string, DragondStats>>();
            Dictionary<string, DragondStats> dragonsAvgStats = new Dictionary<string, DragondStats>();

            for (int i = 0; i < countOfDDragons; i++)
            {
                // "{type} {name} {damage} {health} {armor}"

                string[] arguments = Console.ReadLine().Split();
                string type = arguments[0];
                string name = arguments[1];
                int damage = 45;
                int health = 250;
                int armor = 10;

                if (arguments[2] != "null")
                {
                    damage = int.Parse(arguments[2]);
                }

                if (arguments[3] != "null")
                {
                    health = int.Parse(arguments[3]);
                }


                if (arguments[4] != "null")
                {
                    armor = int.Parse(arguments[4]);
                }

                if (!dragonsInfos.ContainsKey(type))
                {
                    dragonsInfos.Add(type, new Dictionary<string, DragondStats>());
                    DragondStats currDragon = new DragondStats(damage, health, armor);
                    dragonsInfos[type].Add(name, currDragon);
                }

                else if (dragonsInfos.ContainsKey(type) && !dragonsInfos[type].ContainsKey(name))
                {
                    DragondStats currDragon = new DragondStats(damage, health, armor);
                    dragonsInfos[type].Add(name, currDragon);
                }

                else if (dragonsInfos.ContainsKey(type) && dragonsInfos[type].ContainsKey(name))
                {
                    DragondStats currDragon = new DragondStats(damage, health, armor);
                    dragonsInfos[type][name] = currDragon;
                }
            }

            foreach (var dragon in dragonsInfos)
            {
                var currType = dragon.Value;
                double totalDamage = 0;
                double totalHealth = 0;
                double totalArmor = 0;

                foreach (var stat in currType)
                {
                    totalDamage += stat.Value.Damage;
                    totalHealth += stat.Value.Health;
                    totalArmor += stat.Value.Armor;

                }

                totalDamage /= dragon.Value.Count;
                totalHealth /= dragon.Value.Count;
                totalArmor /= dragon.Value.Count;

                DragondStats avgStats = new DragondStats(totalDamage, totalHealth, totalArmor);

                dragonsAvgStats.Add(dragon.Key, avgStats);
            }

            foreach (var stat in dragonsAvgStats)
            {
                Console.WriteLine($"{stat.Key}::({stat.Value.Damage:f2}/{stat.Value.Health:f2}/{stat.Value.Armor:f2})");
                string currType = stat.Key;

                foreach (var dragon in dragonsInfos)
                {
                    if (dragon.Key == currType)
                    {
                        foreach (var nameOfDragon in dragon.Value.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"-{nameOfDragon.Key} -> damage: {nameOfDragon.Value.Damage}, health: {nameOfDragon.Value.Health}, armor: {nameOfDragon.Value.Armor}");
                        }
                        break;
                    }
                }
            }
        }
    }

    class DragondStats
    {
        public DragondStats(double damage, double health, double armor)
        {
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }

    }
}
