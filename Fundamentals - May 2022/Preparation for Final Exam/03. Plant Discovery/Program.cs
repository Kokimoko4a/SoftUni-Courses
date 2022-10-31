using System;
using System.Collections.Generic;

namespace _03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPlants = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plantInfos = new Dictionary<string, Plant>();

            for (int i = 0; i < countOfPlants; i++)
            {
                string[] arguments = Console.ReadLine().Split("<->");
                string name = arguments[0];
                int rarity = int.Parse(arguments[1]);

                Plant currPlant = new Plant(rarity, 0);

                if (!plantInfos.ContainsKey(name))
                {
                    plantInfos.Add(name, currPlant);
                }

                else
                {
                    plantInfos[name] = currPlant;
                }
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                char[] separators = { ' ', ':', '-' };
                string[] arguments = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];

                if (action == "Rate")
                {
                    string plantName = arguments[1];
                    double rating = double.Parse(arguments[2]);

                    if (plantInfos.ContainsKey(plantName))
                    {
                        plantInfos[plantName].Rating += rating;
                        plantInfos[plantName].Count += 1;
                    }

                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else if (action == "Update")
                {
                    string plantName = arguments[1];
                    double newRarity = double.Parse(arguments[2]);

                    if (plantInfos.ContainsKey(plantName))
                    {
                        plantInfos[plantName].Rarity = newRarity;
                    }

                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else if (action == "Reset")
                {
                    string plantName = arguments[1];

                    if (plantInfos.ContainsKey(plantName))
                    {
                        plantInfos[plantName].Rating = 0;
                        plantInfos[plantName].Count = 0;
                    }

                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plantInfos)
            {
                // - { plant_name1}; Rarity: { rarity}; Rating: { average_rating}

                if (plant.Value.Count > 0)
                {
                    double avgRariry = plant.Value.Rating / plant.Value.Count;

                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {avgRariry:f2}");
                }

                else
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plant.Value.Rating:f2}");
                }
            }
        }
    }

    class Plant
    {
        public Plant(double rarity, double rating)
        {
            Rating = rating;
            Rarity = rarity;
        }
        public double Rarity { get; set; }
        public double Rating { get; set; }
        public double Count { get; set; }
    }
}
