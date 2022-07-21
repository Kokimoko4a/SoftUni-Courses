using System;
using System.Text;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] tokens = command.Split(":|:");
                string action = tokens[0];

                if (action == "Reverse")
                {
                    string substring = tokens[1];

                    if (message.Contains(substring))
                    {
                        string cut = message.Substring(message.IndexOf(substring), substring.Length);
                        StringBuilder reversedCut = new StringBuilder();

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedCut.Append(substring[i]);
                        }

                        message = message.Remove(message.IndexOf(substring), substring.Length);
                        message += reversedCut;
                        Console.WriteLine(message );
                    }

                    else
                    {
                        Console.WriteLine("error");
                    }                
                }

                else if (action == "ChangeAll")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];

                    message = message.Replace(oldString, newString);
                    Console.WriteLine(message );
                }

                else if (action == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);

                    message = message.Insert(index, " ");
                    Console.WriteLine(message );
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
