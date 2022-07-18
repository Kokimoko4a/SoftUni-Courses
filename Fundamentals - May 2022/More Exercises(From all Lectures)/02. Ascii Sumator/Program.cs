using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string randomString = Console.ReadLine();
            List<char> charsBetween = new List<char>();
            int sum = 0;

            for (int i = firstChar + 1; i < secondChar; i++)
            {
                charsBetween.Add((char)i);
            }

            foreach (var letter in randomString)
            {
                foreach (var charec in charsBetween)
                {
                    if (letter == charec)
                    {
                        sum += charec;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
