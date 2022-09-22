using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentsAndCountries = new Dictionary<string, Dictionary<string, List<string>>>();
            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!continentsAndCountries.ContainsKey(continent))
                {
                    continentsAndCountries.Add(continent, new Dictionary<string, List<string>>());       
                }

                if (!continentsAndCountries[continent].ContainsKey(country))
                {
                    continentsAndCountries[continent].Add(country, new List<string>());
                }

                continentsAndCountries[continent][country].Add(city);
            }

            foreach (var continent in continentsAndCountries)
            {
                Console.WriteLine(continent.Key + ":");

                foreach (var country in continent.Value)
                {
                    Console.Write( " " + country.Key + " -> ");
                    Console.WriteLine(String.Join(", ",country.Value ));
                }
            }
        }
    }
}
