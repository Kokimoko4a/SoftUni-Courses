using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            string[] words = { "pear", "flour", "pork", "olive" };
            string[] copyWords = { "pear", "flour", "pork", "olive"};

            while (consonants.Count>0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Contains(currVowel))
                    {
                        words[i] = words[i].Replace(currVowel, '0');
                    }

                    if (words[i].Contains(currConsonant))
                    {
                        words[i] = words[i].Replace(currConsonant, '0');
                    }
                }

                vowels.Enqueue(currVowel);
            }

            int count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "0000" || words[i] == "00000")
                {
                    count++;
                }
            }

            Console.WriteLine($"Words found: {count}");

            for (int i = 0; i < words.Length; i++)
            {      
                    if (words[i] == "0000" || words[i] == "00000")
                    {
                        Console.WriteLine(copyWords[i]);         
                    }              
            }
        }
    }
}
