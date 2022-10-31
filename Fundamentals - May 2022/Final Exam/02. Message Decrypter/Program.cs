using System;
using System.Text.RegularExpressions;

namespace _02._Message_Decrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfMessages = int.Parse(Console.ReadLine());
            string pattern = @"^(?<sep>[$%])(?<tag>[A-Z][a-z]{2,})\k<sep>: \[(?<first>[0-9]+)\]\|\[(?<second>[0-9]+)\]\|\[(?<third>[0-9]+)\]\|$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < countOfMessages; i++)
            {
                string currMessage = Console.ReadLine();
                bool isValid = regex.IsMatch(currMessage);

                if (isValid)
                {
                    Match currMatch = regex.Match(currMessage);
                    int firstAsci = int.Parse(currMatch.Groups["first"].ToString());
                    int secondAsci = int.Parse(currMatch.Groups["second"].ToString());
                    int thirdAsci = int.Parse(currMatch.Groups["third"].ToString());

                    string decryptedMessage = string.Empty;

                    decryptedMessage += (char)firstAsci;
                    decryptedMessage += (char)secondAsci;
                    decryptedMessage += (char)thirdAsci;

                    Console.WriteLine($"{currMatch .Groups["tag"]}: {decryptedMessage}");
                }

                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
