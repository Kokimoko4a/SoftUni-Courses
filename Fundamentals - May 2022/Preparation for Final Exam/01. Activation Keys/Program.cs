using System;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] tokens = command.Split(">>>");
                string action = tokens[0];

                if (action == "Flip")
                {
                    string typeFlip = tokens[1];
                    int startIndex = int.Parse(tokens[2]); //включително
                    int endIndex = int.Parse(tokens[3]); //невключително;
                    if (typeFlip == "Lower")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            string alpha = rawKey[i].ToString().ToLower();
                            rawKey = rawKey.Insert(i, alpha);
                            rawKey = rawKey.Remove(i + 1, 1);
                        }
                    }

                    else if (typeFlip == "Upper")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            string alpha = rawKey[i].ToString().ToUpper();
                            rawKey = rawKey.Insert(i, alpha);
                            rawKey = rawKey.Remove(i + 1, 1);
                        }
                    }

                    Console.WriteLine(rawKey);
                }

                else if (action == "Slice")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(rawKey);
                }

                else if (action == "Contains")
                {
                    // "{raw activation key} contains {substring}".
                    // Otherwise, prints: "Substring not found!"

                    string substring = tokens[1];

                    if (rawKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }

                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
