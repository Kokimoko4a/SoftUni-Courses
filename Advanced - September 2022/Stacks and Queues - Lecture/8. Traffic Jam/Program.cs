using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCarsThatCanCross = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    if (cars.Count > 0)
                    {
                        if (cars.Count >= passedCars)
                        {
                            for (int i = 0; i < countOfCarsThatCanCross; i++)
                            {
                                Console.WriteLine($"{cars.Dequeue()} passed!");
                                passedCars++;
                            }
                        }

                        else
                        {
                            for (int i = 0; i < cars.Count; i++)
                            {
                                Console.WriteLine($"{cars.Dequeue()} passed!");
                                passedCars++;
                                i--;
                            }
                        }
                    }
                }

                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
