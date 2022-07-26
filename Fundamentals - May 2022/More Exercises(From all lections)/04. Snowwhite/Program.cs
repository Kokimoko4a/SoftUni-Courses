using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dwarvesInfo = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();

            while (command != "Once upon a time")
            {
                string[] arguments = command.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                string hatColour = arguments[1];
                int physics = int.Parse(arguments[2]);

                if (!dwarvesInfo.ContainsKey(hatColour))
                {
                    dwarvesInfo.Add(hatColour, new Dictionary<string, int>());
                    dwarvesInfo[hatColour].Add(name, physics);
                }

                else if (dwarvesInfo.ContainsKey(hatColour) && !dwarvesInfo[hatColour].ContainsKey(name))
                {
                    dwarvesInfo[hatColour].Add(name, physics);
                }

                else if (dwarvesInfo.ContainsKey(hatColour) && dwarvesInfo[hatColour].ContainsKey(name))
                {
                    if (physics > dwarvesInfo[hatColour][name])
                    {
                        dwarvesInfo[hatColour][name] = physics;
                    }
                }

                command = Console.ReadLine();
            }


            dwarvesInfo = dwarvesInfo.OrderByDescending(x => x.Value).ToDictionary(s => s.Key, s => s.Value);

            foreach (var dwarf in dwarvesInfo)
            {
                Console.WriteLine($"({dwarf.Key}) {dwarf.Value}");


            }
        }
    }
}
