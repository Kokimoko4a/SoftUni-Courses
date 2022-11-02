using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<RobotAndMan> robotsAndMen = new List<RobotAndMan>();

            while (command != "End")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arguments.Length == 3)
                {
                    Man basicMan = new Man(arguments[0], int.Parse(arguments[1]), arguments[2]);
                    robotsAndMen.Add(basicMan);
                }

                else
                {
                    Robot robot = new Robot(arguments[0], arguments[1]);
                    robotsAndMen.Add(robot);    
                }

   
                command = Console.ReadLine();   
            }

            string filter = Console.ReadLine();

            foreach (var item in robotsAndMen.Where(x=>x.Id.EndsWith(filter)))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
