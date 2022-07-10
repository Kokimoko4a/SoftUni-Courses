using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfSynonyms = int.Parse(Console.ReadLine());
            Dictionary<string,List<string>> synonyms = new Dictionary<string,List<string>>();


            for (int i = 0; i < countOfSynonyms; i++)
            {
                string word  = Console.ReadLine();
                string synonym  = Console.ReadLine();

                if (synonyms.ContainsKey (word))
                {
                    synonyms[word].Add(synonym); 
                }

                else
                {
                    synonyms.Add(word,new List<string> ());
                    synonyms[word].Add(synonym); 
                   
                }

            }

            foreach (var word in synonyms )
            {
                Console.Write($"{word.Key } - ");
                Console.Write(String .Join (", ", word.Value ));
                Console.WriteLine();
            }

           
        }
    }
}
