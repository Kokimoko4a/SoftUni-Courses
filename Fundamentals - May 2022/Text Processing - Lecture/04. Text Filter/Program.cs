using System;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var word in bannedWords )
            {
                string asterisks = new string('*', word.Length);
                text = text .Replace (word, asterisks);
            }

            Console.WriteLine(text );
        }
    }
}
