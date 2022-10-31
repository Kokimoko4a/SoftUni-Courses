using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            string command = Console.ReadLine();

            while (command != "PARTY")
            {
                guests.Add(command);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "END")
            {
                guests.Remove(command);

                command = Console.ReadLine();

            }


            HashSet<string> VIPs = new HashSet<string>();

            Console.WriteLine(guests.Count);

            foreach (var item in guests)
            {
                if (char.IsDigit(item[0]))
                {
                    VIPs.Add(item);

                }
            }

            if (VIPs.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, VIPs));
            }


            foreach (var item in guests)
            {
                if (!char.IsDigit(item[0]))
                {
                    Console.WriteLine(item);

                }
            }
        }
    }
}
