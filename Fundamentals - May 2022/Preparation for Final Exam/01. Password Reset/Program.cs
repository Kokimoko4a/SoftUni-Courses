using System;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "TakeOdd")
                {
                    string newPassword = string.Empty;

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newPassword += password[i];
                        }
                    }

                    password = newPassword;
                    Console.WriteLine(password);
                }

                else if (action == "Cut")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);

                    password = password.Remove(startIndex, length);
                    Console.WriteLine(password);
                }

                else if (action == "Substitute")
                {
                    string stringToReplace = tokens[1];
                    string stringToReplaceWith = tokens[2];

                    if (password.Contains(stringToReplace))
                    {
                        password = password.Replace(stringToReplace, stringToReplaceWith);
                        Console.WriteLine(password);
                    }

                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine();

            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
