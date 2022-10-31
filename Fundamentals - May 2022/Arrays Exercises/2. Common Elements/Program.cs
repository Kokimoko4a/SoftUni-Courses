using System;

namespace _2._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text1 = Console.ReadLine().Split();
            string[] text2 = Console.ReadLine().Split();

            for (int i = 0; i < text1.Length; i++)
            {
                for (int k = 0; k < text2.Length; k++)
                {
                    if (text1[i] == text2[k])
                    {
                        Console.Write($"{text1[i]} ");
                    }
                }
            }
        }
    }
}
