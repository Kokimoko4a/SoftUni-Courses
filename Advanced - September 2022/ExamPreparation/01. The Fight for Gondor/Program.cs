using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> leftOrcs = new Stack<int>();
            int plate = 0;
            int plate2 = 0;

            for (int i = 1; i <= countOfWaves; i++)
            {
               if (plates.Count > 0)
                {
                    bool isNeed = false;
                    Stack<int> orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                    if (i % 3 == 0 & i != 0)
                    {
                        int newPlate = int.Parse(Console.ReadLine());
                        plates.Enqueue(newPlate);
                    }


                    while (orcs.Count > 0 && plates.Count > 0)
                    {                       
                        if (!isNeed)
                        {
                            int currOrc = orcs.Peek();
                            plate = plates.Peek();

                            if (currOrc > plate)
                            {
                                orcs.Pop();
                                plates.Dequeue();
                                currOrc -= plate;
                                orcs.Push(currOrc);
                            }

                            else if (plate > currOrc)
                            {
                                orcs.Pop();
                                plate -= currOrc;
                                plate2 = plate;
                                isNeed = true;
                            }

                            else
                            {
                                orcs.Pop();
                                plates.Dequeue();
                            }
                        }

                        else
                        {
                            int currOrc = orcs.Peek();
                            plate = plate2;

                            if (currOrc > plate)
                            {
                                orcs.Pop();
                                plates.Dequeue();
                                currOrc -= plate;
                                orcs.Push(currOrc);
                                isNeed = false;
                            }

                            else if (plate > currOrc)
                            {
                                orcs.Pop();
                                plate -= currOrc;
                                plate2 = plate;
                               // isNeed = true;

                            }

                            else
                            {
                                orcs.Pop();
                                plates.Dequeue();
                                isNeed = false;
                            }
                        }
                    }

                    leftOrcs = orcs;
               }

                else
                {
                    break;
                }

            }

            if (plates.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }

            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", leftOrcs)}");
            }
        }
    }
}
