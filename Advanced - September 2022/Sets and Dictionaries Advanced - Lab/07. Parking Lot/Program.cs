using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(", ");

                if (tokens[0] == "IN")
                {
                    set.Add(tokens[1]);
                }

                else
                {
                    set.Remove(tokens[1]);
                }

                command = Console.ReadLine();
            }

            if (set.Count>0)
            {
                Console.WriteLine(String.Join(Environment.NewLine,set));
            }

            else
            {
                Console.WriteLine("Parking Lot is Empty"); 
            }
        }
    }
}
