using System;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfSentences = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfSentences; i++)
            {
                string currSentence = Console.ReadLine();
                string age = string.Empty;
                string name = string.Empty;
                int startIndexForName = currSentence.IndexOf("@");
                int endIndexForName = currSentence.IndexOf("|");

                int startIndexForAge = currSentence.IndexOf("#");
                int endIndexForAge = currSentence.IndexOf("*");

                name = currSentence.Substring(startIndexForName + 1, endIndexForName - startIndexForName - 1);
                age = currSentence.Substring(startIndexForAge + 1, endIndexForAge - startIndexForAge - 1);

                Console.WriteLine($"{name.Trim()} is {age.Trim()} years old.");
            }
        }
    }
}


