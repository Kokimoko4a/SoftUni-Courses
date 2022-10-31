using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Multiplier(input[0] ,input[1]);
        }

        static void Multiplier(string word1, string word2)
        { 

            string longest = word1;
            string shortest = word2;
            int sum = 0;

            if (word1.Length  >word2.Length  )
            {
                longest = word1;
                shortest = word2;
            }

            else if (word2 .Length >word1.Length )
            {
                longest = word2;
                shortest = word1;
            }


            for (int i = 0; i < shortest .Length ; i++)
            {
                sum += longest[i] * shortest[i];
            }

            for (int i = shortest .Length ; i < longest .Length ; i++)
            {
                sum += longest[i];
            }

            Console.WriteLine(sum);
        }
    }
}
