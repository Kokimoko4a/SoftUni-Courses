using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            int shotCounter = 0;

            while (command != "End")
            {
                int pukane = int.Parse(command);
                int copy = 0;

                if (pukane  <input .Length && pukane >=0)
                {
                    if (input[pukane] !=-1)
                    {
                        shotCounter++;
                    }

                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    copy = input[pukane];
                    input[pukane] = -1;

                    for (int i = 0; i < input .Length ; i++)
                    {
                        int currNumber = input[i];

                        if ( currNumber  != -1 && currNumber  > copy)
                        {
                            input[i]   -= copy;
                        }

                        else if (currNumber !=-1 && currNumber <= copy )
                        {
                            input[i] += copy;
                        }
                    }
                }

                command = Console.ReadLine();

            }

            Console.Write($"Shot targets: {shotCounter } -> ");
            Console.Write(String.Join(" ", input));
        }
    }
}
