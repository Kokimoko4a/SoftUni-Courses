using System;

namespace Final_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Abracadabra")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Abjuration")
                {
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                }

                else if (action == "Necromancy")
                {
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                }

                else if (action == "Illusion")
                {
                    int index = int.Parse(tokens[1]);
                    string letter = tokens[2];

                    if (index >= 0 && index < spell.Length)
                    {
                        spell = spell.Insert(index, letter);
                        spell = spell.Remove(index + 1,1);
                        Console.WriteLine("Done!");
                    }

                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                }

                else if (action == "Divination")
                {
                    string oldSubstring = tokens[1];
                    string newSubstring = tokens[2];

                    if (spell.Contains(oldSubstring))
                    {
                        spell = spell.Replace(oldSubstring, newSubstring);
                        Console.WriteLine(spell);
                    }
                }

                else if (action == "Alteration")
                {
                    string substring = tokens[1];

                    if (spell.Contains(substring))
                    {
                        int index = spell.IndexOf(substring);
                        spell = spell.Remove(index, substring.Length);
                        Console.WriteLine(spell);
                    }
                }

                else
                {
                    Console.WriteLine("The spell did not work!");
                }

                command = Console.ReadLine();
            }
        }
    }
}
