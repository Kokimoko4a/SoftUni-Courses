using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            PrintCharacters(start, end);
        }

        private static void PrintCharacters(char start, char end)
        {
            if (end < start)
            {
                char swap = start;
                start = end;
                end = swap;
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
