using System;

namespace T05._Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine ();
            int lenghtOfWord = word.Length;
            for (int index = 0; index <= lenghtOfWord; index++)
            {
                Console.WriteLine($"{word[index]}");
            }
        }
    }
}
