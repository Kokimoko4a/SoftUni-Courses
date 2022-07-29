using System;

namespace _01._Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isValid = false;

            while (!isValid)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsLetter(input[i]))
                    {
                        isValid = false;
                        Console.WriteLine("Invalid username!");
                        input = Console.ReadLine();
                        break;
                    }

                    else
                    {
                        isValid = true;
                    }
                }             
            }
        }
    }
}
