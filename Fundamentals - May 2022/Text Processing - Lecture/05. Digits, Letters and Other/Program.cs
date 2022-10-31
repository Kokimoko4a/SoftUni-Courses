using System;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string letters = "";
            string numbers = "";
            string symbols = "";

            foreach (var thing in text)
            {
                if (char.IsLetter(thing))
                {
                    letters += thing;
                }

                else if (char.IsDigit(thing))
                {
                    numbers += thing;
                }

                else
                {
                    symbols += thing;
                }
            }

            Console.WriteLine(numbers );
            Console.WriteLine(letters );
            Console.WriteLine(symbols );
        }
    }
}
