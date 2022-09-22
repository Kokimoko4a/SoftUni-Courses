using System;
using System.Collections.Generic;
using System.Drawing;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string,int>> clothes = new Dictionary<string, Dictionary<string,int>>();
            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] seps = { " -> ", "," };              
                string[] tokens = Console.ReadLine().Split(seps,StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];
                

                if (!clothes.ContainsKey(color))
                {
                    clothes[color] = new Dictionary<string, int>();
                }

                for (int d = 1; d < tokens.Length; d++)
                {
                    if (!clothes[color].ContainsKey(tokens[d]))
                    {
                        clothes[color].Add(tokens[d], 0);
                    }

                    clothes[color][tokens[d]]++;
                }
            }

            string[] wantedCloth = Console.ReadLine().Split();

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == wantedCloth[0] && cloth.Key == wantedCloth[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {cloth.Key} - { cloth.Value}");
                }
            }
        }
    }
}
