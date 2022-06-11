using System;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower ();
            Console.WriteLine(VowelsCounter(input)); 
        }

        private static int VowelsCounter(string input)
        {
            int counter = 0;
            foreach (char item in input)
            {
                if ("aeoiu".Contains (item))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
