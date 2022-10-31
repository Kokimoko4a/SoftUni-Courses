using System;

namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int energy = int.Parse(Console.ReadLine());
            string command = Console .ReadLine();
            int winsCounter = 0;
            // int bonus = 0;
            int i = 0;
            int leftEnrgy = 0;

            while (command  != "End of battle")
            {
                int distance = int.Parse(command );

                if (winsCounter %3 == 0 && i>0)
                {
                    energy += winsCounter;
                }

                if (energy -distance >0)
                {
                    winsCounter++;
                    energy -= distance;
                }

                else
                {
                    leftEnrgy = energy - distance;
                    if (leftEnrgy <=0)
                    {
                        leftEnrgy = 0;
                    }
                    winsCounter++;

                    Console.WriteLine($"Not enough energy! Game ends with {winsCounter} won battles and {leftEnrgy} energy");
                    return;
                }
               
                command = Console .ReadLine();
                i++;
            }


         

            Console.WriteLine($"Won battles: {winsCounter}. Energy left: {energy}");
        }
    }
}
