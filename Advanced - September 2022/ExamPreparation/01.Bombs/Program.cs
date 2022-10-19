using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Bomb
    {
        public Bomb(string name)
        {
            Name = name;
        }

        public int Count { get; set; }
        public string Name { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombsCasings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<int, Bomb> bombTypes = new Dictionary<int, Bomb>();
            bombTypes.Add(40, new Bomb("Datura Bombs") );
            bombTypes.Add(60, new Bomb("Cherry Bombs") );
            bombTypes.Add(120, new Bomb("Smoke Decoy Bombs") );

            while (bombEffects.Count>0 && bombsCasings.Count>0)
            {
                if (bombTypes.All(x => x.Value.Count >= 3))
                {
                    break;
                }

                int effect = bombEffects.Peek();
                int casing = bombsCasings.Pop();

                if (bombTypes.ContainsKey(effect+casing))
                {
                    bombEffects.Dequeue();
                    bombTypes[effect + casing].Count++;
                }

                else
                {
                    bombsCasings.Push(casing - 5);
                }
            }

            string result = bombTypes.All(x => x.Value.Count >= 3) ? "Bene! You have successfully filled the bomb pouch!" : "You don't have enough materials to fill the bomb pouch.";
            Console.WriteLine(result);

            result = bombEffects.Any() ? $"Bomb Effects: {string.Join(", ", bombEffects)}" : "Bomb Effects: empty";
            Console.WriteLine(result);

            result = bombsCasings.Any() ? $"Bomb Casings: {string.Join(", ", bombsCasings)}" : "Bomb Casings: empty";
            Console.WriteLine(result);

            foreach (var item in bombTypes.OrderBy(x=>x.Value.Name))
            {
                Console.WriteLine($"{item.Value.Name}: {item.Value.Count}");
            }
        }
    }
}
