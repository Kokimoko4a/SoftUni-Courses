using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            Dictionary<string, string> treasuresInfos = new Dictionary<string, string>();


            while (command != "find")
            {
                string currString = string.Empty;
                int currKey = 0;
                int k = 0;

                for (int i = 0; i < command.Length; i++)
                {
                    if (k > keys.Length - 1)
                    {
                        k = 0;
                    }

                    currKey = keys[k];
                    char currentChar = (char)(command[i] - currKey);
                    currString += currentChar;

                    k++;
                }

                int startIndexForTreasureType = currString.IndexOf("&");
                int endIndexForTreasureType = currString.LastIndexOf("&");

                int startIndexForCoordinates = currString.IndexOf("<");
                int endIndexForCoordinates = currString.LastIndexOf(">");

                string typeOfTreasure = currString.Substring(startIndexForTreasureType + 1, endIndexForTreasureType - startIndexForTreasureType - 1);

                string coordinates = currString.Substring(startIndexForCoordinates + 1, endIndexForCoordinates - startIndexForCoordinates - 1);

                treasuresInfos.Add(coordinates, typeOfTreasure);

                command = Console.ReadLine();
            }

            foreach (var treasure in treasuresInfos)
            {
                Console.WriteLine($"Found {treasure.Value} at {treasure.Key}");
            }
        }
    }
}
