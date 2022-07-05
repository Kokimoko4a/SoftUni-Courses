using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console .ReadLine();
            int n = int.Parse(Console.ReadLine());
            RepeatString(n , text ); 
        }

        private static void RepeatString(int n, string text)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(text);
            }
        }
    }
}
