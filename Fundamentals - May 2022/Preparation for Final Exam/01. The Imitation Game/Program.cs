using System;
namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] tokens = command.Split('|');
                string action = tokens[0];

                if (action == "ChangeAll")
                {
                    string letterTochange = tokens[1];
                    string newLetter = tokens[2];
                    input = input.Replace(letterTochange, newLetter);

                }

                else if (action == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string letter = tokens[2];
                    input = input.Insert(index, letter);
                }

                else if (action == "Move")
                {
                    int count = int.Parse(tokens[1]);
                    string neededLetters = input.Substring(0, count);
                    input = input.Remove(0, count);
                    input = input + neededLetters;
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
