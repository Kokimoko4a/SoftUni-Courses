using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split());
            int countOfTosses = int.Parse(Console.ReadLine());
            int currToss = 1;

            while (kids.Count > 1)
            {
                string currKid = kids.Dequeue();

                if (currToss != countOfTosses)
                {
                    currToss++;
                    kids.Enqueue(currKid);
                }

                else
                {
                    currToss = 1;
                    Console.WriteLine($"Removed {currKid}");
                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
