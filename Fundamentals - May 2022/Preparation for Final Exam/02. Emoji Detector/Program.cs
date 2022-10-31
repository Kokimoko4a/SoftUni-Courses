using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<sep>:{2}|\*{2})(?<name>[A-Z][a-z]{2,})\k<sep>";
            Regex regex = new Regex(pattern);
            BigInteger coolThreshold = 1;

            foreach (var item in input)
            {
                if (char.IsDigit(item))
                {
                    int currNumber = int.Parse(item.ToString());
                    coolThreshold *= currNumber;
                }
            }

            MatchCollection validOnes = regex.Matches(input);

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{validOnes.Count} emojis found in the text. The cool ones are:");
            List<string> coolOnes = new List<string>();

            foreach (Match item in validOnes)
            {
                BigInteger currSum = 0;
                string currItem = item.Groups["name"].ToString();

                foreach (var charec in currItem)
                {
                    currSum += charec;
                }

                if (currSum >= coolThreshold)
                {
                    coolOnes.Add(item.ToString());
                }
            }


            Console.WriteLine(string.Join(Environment.NewLine, coolOnes));
        }

    }
}
