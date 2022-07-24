using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternForName = @"[A-Za-z]";
            string patternForDistance = @"[0-9]";
            List<string> names = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();
            Regex regexForName = new Regex(patternForName);
            Regex regexForDistance = new Regex(patternForDistance);
            Dictionary<string, int> racersInfos = new Dictionary<string, int>();

            while (command != "end of race")
            {
                MatchCollection currName = regexForName.Matches(command);
                MatchCollection currDistance = regexForDistance.Matches(command);
                string nameAsString = string.Empty;
                int currDistanceAsInt = 0;

                foreach (Match item in currName)
                {
                    nameAsString += item;
                }

                foreach (Match item in currDistance)
                {
                    currDistanceAsInt += int.Parse(item.ToString());
                }

                if (names.Contains(nameAsString))
                {
                    if (!racersInfos.ContainsKey(nameAsString))
                    {
                        racersInfos.Add(nameAsString, currDistanceAsInt);
                    }

                    else
                    {
                        racersInfos[nameAsString] += currDistanceAsInt;
                    }
                }

                command = Console.ReadLine();
            }

            string nonSennese = "0";

            racersInfos = racersInfos.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            /*"1st place: {first racer}
            2nd place: { second racer}
            3rd place: { third racer}
            "*/

            string currRaceer = "";
            foreach (var item in racersInfos )
            {
                Console.WriteLine($"1st place: {item.Key }");
                currRaceer = item.Key;
                break;
            }

            racersInfos.Remove(currRaceer);
             currRaceer = "";

            foreach (var item in racersInfos)
            {
                Console.WriteLine($"2nd place: {item.Key}");
                currRaceer = item.Key;
                break;
            }

            racersInfos.Remove(currRaceer);        

            foreach (var item in racersInfos )
            {
                Console.WriteLine($"3rd place: {item.Key}");
                break;
            }
        }
    }
}
