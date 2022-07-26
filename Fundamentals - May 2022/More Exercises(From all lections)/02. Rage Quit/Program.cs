using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string angryMessage = Console.ReadLine().ToUpper();
            string pattern = @"(?<message>[^\d]+)(?<times>[0-9]+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(angryMessage);
            List<char> uniqueSymbols = new List<char>();

            foreach (Match item in matches)
            {
                string message = item.Groups["message"].ToString();
                int times = int.Parse(item.Groups["times"].ToString());

                if (times > 0)
                {
                    foreach (var charec in message)
                    {
                        if (!uniqueSymbols.Contains(charec))
                        {
                            uniqueSymbols.Add(charec);
                        }
                    }
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");

            foreach (Match item in matches)
            {
                int times = int.Parse(item.Groups["times"].ToString());


                for (int i = 0; i < times; i++)
                {
                    Console.Write(item.Groups["message"]);
                }

            }
        }
    }
}
