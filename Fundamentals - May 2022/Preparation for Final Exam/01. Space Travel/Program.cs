using System;
using System.Text.RegularExpressions;

namespace _01._Space_Travel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string planetName = Console.ReadLine();
            string pattern = @"[0-9]{2}";
            Regex regex = new Regex(pattern);
            string encryptedMessage = Console.ReadLine();
            MatchCollection messages = regex.Matches(encryptedMessage);
            string decodedMessage = string.Empty ;

            foreach (Match item in messages  )
            {
                int currLetterCode = int.Parse (item.Value); 
                char currLetter = (char)currLetterCode;
                decodedMessage+=currLetter;
            }

           /* if (decodedMessage == "GO HOME")
            {
                Console.WriteLine("Going home.");
                return;
            }*/

            while (decodedMessage !="GO HOME")
            {
                Console.WriteLine(decodedMessage );
                planetName = Console.ReadLine();
                encryptedMessage = Console.ReadLine();
                decodedMessage = string.Empty;

                 messages = regex.Matches(encryptedMessage);

                foreach (Match item in messages)
                {
                    int currLetterCode = int.Parse(item.Value);
                    char currLetter = (char)currLetterCode;
                    decodedMessage += currLetter;
                }
            }

            Console.WriteLine("GO HOME");
            Console.WriteLine("Going home.");
        }
    }
}
