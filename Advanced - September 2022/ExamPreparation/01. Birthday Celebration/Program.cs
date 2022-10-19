using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int wastedFood = 0;

            while (plates.Count > 0 && guests.Count > 0)
            {
                int currPlate = plates.Pop();
                int currGuest = guests.Peek();

                if (currPlate == guests.Peek())
                {
                    guests.Dequeue();
                }

                else if (currPlate > guests.Peek())
                {
                    wastedFood += currPlate - guests.Peek();
                    guests.Dequeue();
                }

                else if (guests.Peek() > currPlate)
                {
                    while (currGuest > 0 && plates.Count > 0)
                    {
                        if (currPlate>currGuest)
                        {
                            wastedFood += currPlate- currGuest;
                        }

                       else if (currGuest>currPlate)
                        {
                            currGuest -= currPlate;
                            currPlate = plates.Pop();
                        }

                        else
                        {
                            break;
                        }
                      
                    }

                    guests.Dequeue();
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
