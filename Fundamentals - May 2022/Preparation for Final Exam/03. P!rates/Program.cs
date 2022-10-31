using System;
using System.Collections.Generic;

namespace _03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Town> townsInfos = new Dictionary<string, Town>();
            string command = Console.ReadLine();

            while (command != "Sail")
            {
                string[] arguments = command.Split("||");
                string nameOfTown = arguments[0];
                int currPopulation = int.Parse(arguments[1]);
                int currAmountOfGold = int.Parse(arguments[2]);

                if (townsInfos.ContainsKey(nameOfTown))
                {
                    townsInfos[nameOfTown].Population += currPopulation;
                    townsInfos[nameOfTown].AmountOfGold += currAmountOfGold;
                }

                else
                {
                    Town currTown = new Town(currPopulation, currAmountOfGold);
                    townsInfos.Add(nameOfTown, currTown);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] arguments = command.Split("=>");
                string action = arguments[0];

                if (action == "Plunder")
                {
                    string townToPlunder = arguments[1];
                    int killedPeople = int.Parse(arguments[2]);
                    int plunderedGold = int.Parse(arguments[3]);

                    townsInfos[townToPlunder].Population -= killedPeople;
                    townsInfos[townToPlunder].AmountOfGold -= plunderedGold;

                    Console.WriteLine($"{townToPlunder} plundered! {plunderedGold} gold stolen, {killedPeople} citizens killed.");

                    if (townsInfos[townToPlunder].Population <= 0 || townsInfos[townToPlunder].AmountOfGold <= 0)
                    {
                        townsInfos.Remove(townToPlunder);
                        Console.WriteLine($"{townToPlunder} has been wiped off the map!");
                    }
                }

                else if (action == "Prosper")
                {
                    string town = arguments[1];
                    int prosperedGold = int.Parse(arguments[2]);

                    if (prosperedGold >= 0)
                    {
                        townsInfos[town].AmountOfGold += prosperedGold;
                        Console.WriteLine($"{prosperedGold} gold added to the city treasury. {town} now has {townsInfos[town].AmountOfGold} gold.");
                    }

                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }

                command = Console.ReadLine();
            }

            if (townsInfos.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townsInfos.Count} wealthy settlements to go to:");

                foreach (var town in townsInfos)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.AmountOfGold} kg");
                }
            }

            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class Town
    {
        public Town(int population, int amountOfGold)
        {
            Population = population;
            AmountOfGold = amountOfGold;
        }

        public int Population { get; set; }
        public int AmountOfGold { get; set; }
    }
}
