using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, Location> locationsAndTiles = new Dictionary<string, Location>();
            locationsAndTiles.Add("40", new Location("Sink", 0));
            locationsAndTiles.Add("50", new Location("Oven", 0));
            locationsAndTiles.Add("60", new Location("Countertop", 0));
            locationsAndTiles.Add("70", new Location("Wall", 0));
            locationsAndTiles.Add("Floor", new Location("Floor", 0));


            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currWhiteTile = whiteTiles.Pop();
                int currGreyTile = greyTiles.Dequeue();
                int newTile = currWhiteTile + currGreyTile;

                if (currWhiteTile == currGreyTile)
                {
                    if (locationsAndTiles.ContainsKey(newTile.ToString()))
                    {
                        locationsAndTiles[newTile.ToString()].Count++;
                    }

                    else
                    {
                        locationsAndTiles["Floor"].Count++;
                    }
                }

                else
                {
                    currWhiteTile /= 2;
                    whiteTiles.Push(currWhiteTile);
                    greyTiles.Enqueue(currGreyTile);
                }
            }

            if (whiteTiles.Count>1)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles)}");
            }

            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Count > 1)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var item in locationsAndTiles.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Value.Name).Where(x=>x.Value.Count>0))
            {
                Console.WriteLine($"{item.Value.Name}: {item.Value.Count}");
            }
        }
    }

    class Location
    {
        public Location(string name, int count)
        {
            Name = name;
            Count = count;
        }
        public string Name { get; set; }
        public int Count { get; set; }

    }
}
