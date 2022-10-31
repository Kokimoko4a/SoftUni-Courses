using System;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] arguments = command.Split(":");
                string action = arguments[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(arguments[1]);
                    string stop = arguments[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, stop);
                        //Console.WriteLine(stops);
                    }
                }

                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(arguments[1]);
                    int endIndex = int.Parse(arguments[2]);

                    if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length)
                    {
                        int count = endIndex - startIndex + 1;
                        stops = stops.Remove(startIndex, count);
                    }
                }

                else if (action == "Switch")
                {
                    string oldString = arguments[1];
                    string newString = arguments[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);

                    }
                }

                Console.WriteLine(stops);
                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
