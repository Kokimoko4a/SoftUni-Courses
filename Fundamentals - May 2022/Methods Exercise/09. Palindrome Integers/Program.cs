using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                Console.WriteLine(Palindrome(input)); 
            }
        }

        private static string  Palindrome(string input)
        {
            string palindrome = string.Empty;
            int numbers = int.Parse(input);

            while (numbers > 0)
            {


                palindrome += numbers % 10;
                numbers /= 10;


            }

            if (palindrome == input)
            {
                return "true";
            }

            else
            {
                return "false";
            }
        }
    }
}
