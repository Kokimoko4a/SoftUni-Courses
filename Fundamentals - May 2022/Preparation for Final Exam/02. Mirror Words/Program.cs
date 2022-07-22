using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> wordPairs = new Dictionary<string, string>();
            string input = Console.ReadLine();
            string pattern = @"(?<sep>[\#@])(?<word1>[A-Z a-z]{3,})\k<sep>\k<sep>(?<word2>[a-z A-Z]{3,})\k<sep>";
            Regex regex = new Regex(pattern);
            MatchCollection validOnes = regex.Matches(input);

            if (validOnes.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine($"{validOnes.Count} word pairs found!");

            foreach (Match item in validOnes)
            {
                StringBuilder word2Rev = new StringBuilder();
                string word2 = item.Groups["word2"].ToString();
                string word1 = item.Groups["word1"].ToString();

                for (int i = word2.Length - 1; i >= 0; i--)
                {
                    word2Rev.Append(word2[i]);
                }

                string word2RevAsString = word2Rev.ToString();

                if (word2RevAsString == word1)
                {
                    wordPairs.Add(word1, word2);
                }
            }

            if (wordPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
                return;

            }

            int k = 0;
            Console.WriteLine("The mirror words are:");

            foreach (var item in wordPairs)
            {
                k++;

                if (k == wordPairs.Count)
                {
                    Console.WriteLine($"{item.Key} <=> {item.Value}");
                    break;
                }

                Console.Write($"{item.Key} <=> {item.Value}, ");
            }
        }
    }
}
