using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Dictionary<double, Bakery> bakery = new Dictionary<double, Bakery>();
            bakery.Add(50, new Bakery ("Croissant",0)); ;
            bakery.Add(40, new Bakery("Muffin",0));
            bakery.Add(30, new Bakery("Baguette",0));
            bakery.Add(20, new Bakery("Bagel", 0));

            while (water.Any() && flour.Any())
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();
                double waterPercantage = 0;
                double flourPercantage = 0;
                double sum = currWater + currFlour;

                waterPercantage = currWater * 100 / sum;
                flourPercantage = currFlour * 100 / sum;

                if (bakery.ContainsKey(waterPercantage))
                {
                    bakery[waterPercantage].Count++;
                }

                else
                {
                    flour.Push(currFlour - currWater); 
                    bakery[50].Count++;
                }
            }



            foreach (var item in bakery.Where(x=>x.Value.Count>0).OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Value.Name))
            {
                Console.WriteLine($"{item.Value.Name}: {item.Value.Count}");
            }

            if (water.Count>0)
            {
                Console.WriteLine($"Water left: {string.Join(", ",water)}");
            }

            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count>0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ",flour)}");
            }

            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }

    class Bakery
    {
        public Bakery(string name, int count)
        {
            Count = count;
            Name = name;
        }

        public int Count { get; set; }

        public string  Name { get; set; }
    }
}
