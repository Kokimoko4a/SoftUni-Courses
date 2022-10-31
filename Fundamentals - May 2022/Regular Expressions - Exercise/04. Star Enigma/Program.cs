using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[^@\-!:>]*@(?<name>[A-Za-z]+)[^@\-!:>]*:\d+[^@\-!:>]*![^@\-!:>]*(?<type>[AD])![^@\-!:>]*->[^@\-!:>]*\d[^@\-!:>]*";
            Regex regex = new Regex(pattern);
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            int countOfPlanets = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPlanets; i++)
            {
                string currPlanet = Console.ReadLine();
                string currPlanetLowered = currPlanet.ToLower();
                int key = currPlanetLowered.Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');
                currPlanetLowered = string.Empty;

                for (int k = 0; k < currPlanet.Length; k++)
                {
                    char letter = (char)(currPlanet[k] - key);
                    currPlanetLowered += letter;
                }

                bool isValid = regex.IsMatch(currPlanetLowered);

                if (isValid)
                {
                    Match match = regex.Match(currPlanetLowered);

                    if (match.Groups["type"].ToString() == "A")
                    {
                        attacked.Add(match.Groups["name"].ToString());
                    }

                    else if (match.Groups["type"].ToString() == "D")
                    {
                        destroyed.Add(match.Groups["name"].ToString());
                    }

                }
            }

            /*"Attacked planets: {attackedPlanetsCount}"
            "-> {planetName}"
            "Destroyed planets: {destroyedPlanetsCount}"
            "-> {planetName}"*/

            Console.WriteLine($"Attacked planets: {attacked.Count}");

            foreach (var item in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");

            foreach (var item in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
