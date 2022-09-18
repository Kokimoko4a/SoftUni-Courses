using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int originalCapacity = rackCapacity;
            int usedRacks = 1;

            while (clothes.Any())
            {
                int currentCloth = clothes.Peek();

                if (rackCapacity-currentCloth>0)
                {
                    rackCapacity -= currentCloth;
                    clothes.Pop();
                }

                else if (rackCapacity - currentCloth == 0 && clothes.Count>1)
                {
                    usedRacks++;
                    rackCapacity =originalCapacity;
                    clothes.Pop();
                }

                else if (rackCapacity - currentCloth <0 && clothes.Count>1)
                {
                    usedRacks++;
                    rackCapacity = originalCapacity;
                    clothes.Pop();
                }


                if (clothes.Count>0)
                {
                    if (clothes.Peek() > rackCapacity)
                    {
                        usedRacks++;
                        rackCapacity = originalCapacity;
                    }
                }
                
            }

            Console.WriteLine(usedRacks);
        }
    }
}
