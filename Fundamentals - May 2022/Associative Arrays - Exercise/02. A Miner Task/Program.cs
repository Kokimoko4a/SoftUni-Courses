using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            // int i = 1;
            Dictionary<string, int> resources = new Dictionary<string, int>();


            while (command != "stop")
            {

                if (resources.ContainsKey(command))
                {
                    resources[command] += quantity;
                }

                else
                {
                    resources.Add(command, quantity);
                }

                command = Console.ReadLine();

                if (command == "stop")
                {
                    break;
                }

                quantity = int.Parse(Console.ReadLine());
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
