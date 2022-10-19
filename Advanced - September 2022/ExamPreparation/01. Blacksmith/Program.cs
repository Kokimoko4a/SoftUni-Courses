using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<double, Sword> weaponary = new Dictionary<double, Sword>();
            weaponary.Add(150, new Sword("Broadsword", 0)); ;
            weaponary.Add(110, new Sword("Sabre", 0));
            weaponary.Add(90, new Sword("Katana", 0));
            weaponary.Add(80, new Sword("Shamshir", 0));
            weaponary.Add(70, new Sword("Gladius", 0));

            while (steel.Count>0 && carbon.Count>0)
            {
                int currSteel = steel.Dequeue();
                int currCarbon = carbon.Pop();
                int mix = currCarbon + currSteel;

                if (weaponary.ContainsKey(mix))
                {
                    weaponary[mix].Count++;
                }

                else
                {
                    currCarbon += 5;
                    carbon.Push(currCarbon);
                }
            }

            if (weaponary.Any(x=>x.Value.Count>0))
            {
                int count = 0;

                foreach (var weapon in weaponary)
                {
                    if (weapon.Value.Count>0)
                    {
                        count+=weapon.Value.Count;
                    }
                }

                Console.WriteLine($"You have forged {count} swords.");
            }

            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }

            else 
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count>0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ",carbon)}");
            }

            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var item in weaponary.Where(x=>x.Value.Count>0).OrderBy(x=>x.Value.Name))
            {
                Console.WriteLine($"{item.Value.Name}: {item.Value.Count}");  
            }
        }
    }

    class Sword
    {
        public Sword(string name, int count)
        {
            Count = count;
            Name = name;
        }

        public int Count { get; set; }

        public string Name { get; set; }
    }
}
