using System;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            foreach (var word in text )
            {
                for (int i = 0; i < word.Length ; i++)
                {
                    Console.Write(word);
                }
            }
        }
    }
}
