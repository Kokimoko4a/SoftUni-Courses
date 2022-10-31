using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<char, int> wordsWithTheirOcuurences = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currWord = input[i];

                for (int k = 0; k < currWord.Length; k++)
                {
                    var currLetter = currWord[k];

                    if (wordsWithTheirOcuurences.ContainsKey(currLetter))
                    {
                        wordsWithTheirOcuurences[currLetter]++;
                    }

                    else
                    {
                        wordsWithTheirOcuurences.Add(currLetter, 1);
                    }
                }

            }

            foreach (var letter in wordsWithTheirOcuurences)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
