using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, string> peolplesAndLicesenseNumbers = new Dictionary<string, string>();

            for (int i = 0; i < countOfCars; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string action = arguments[0];
                string name = arguments[1];
              
                if (action == "register")
                {
                    string licenseNumber = arguments[2];

                    if (!peolplesAndLicesenseNumbers.ContainsKey(name))
                    {
                        peolplesAndLicesenseNumbers.Add(name, licenseNumber);
                        Console.WriteLine($"{name} registered {licenseNumber} successfully");
                    }

                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licenseNumber}");
                    }
                }

                else if (action == "unregister")
                {
                    if (peolplesAndLicesenseNumbers.ContainsKey(name))
                    {
                        peolplesAndLicesenseNumbers.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }

                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }

            foreach (var user in peolplesAndLicesenseNumbers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
