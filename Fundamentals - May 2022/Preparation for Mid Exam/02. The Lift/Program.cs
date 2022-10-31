
using System;
using System.Linq;

namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int copyPeople = people;
            int[] liftSeats = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool hasEmptySpots = false;

            int i = 0;

            while (people > 0)
            {
                if (i >= liftSeats.Length)
                {
                    break;
                }

                if (liftSeats[i] > 0)
                {
                    if (people <4)
                    {
                        liftSeats[i] +=people-liftSeats[i];
                        people -=people -liftSeats[i];
                        i++;
                        continue;
                    }

                    else
                    {
                        people -= 4 - liftSeats[i];
                        liftSeats[i] += 4-liftSeats[i];
                        i++;
                        continue;
                    }
                   
                }

                if (people >= 4)
                {
                    liftSeats[i] = 4;
                    people -= 4;
                }

                else
                {
                    liftSeats[i] = people;
                    people -= liftSeats[i];
                }


                i++;
            }

            foreach (var lift in liftSeats)
            {
                if (lift < 4)
                {
                    hasEmptySpots = true;
                    Console.WriteLine("The lift has empty spots!");
                    Console.WriteLine(String.Join(" ", liftSeats));
                    return;
                }
            }

            if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(String.Join(" ", liftSeats));
                return;
            }

            Console.WriteLine(String .Join(" ",liftSeats ));


        }
    }
}
