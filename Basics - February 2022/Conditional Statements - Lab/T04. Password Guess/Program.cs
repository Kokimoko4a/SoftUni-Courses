using System;

namespace T04._Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            bool isSecretWordCorrect = word == "s3cr3t!P@ssw0rd";
            if (isSecretWordCorrect)
            {
                Console.WriteLine("Welcome");
            }
            else {
                Console.WriteLine("Wrong password!");
            }


        }
    }
}
