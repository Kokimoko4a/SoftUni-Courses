using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> miligramsCaffeine = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int drankCaffeine = 0;

            while (miligramsCaffeine.Count>0 && energyDrinks.Count>0)
            {
                int currDrink = energyDrinks.Dequeue();
                int currMG = miligramsCaffeine.Pop();
                int currEnergy = currDrink * currMG;

                if (currEnergy+drankCaffeine<=300)
                {
                    drankCaffeine += currEnergy;
                }

                else
                {
                    energyDrinks.Enqueue(currDrink);

                    if (!(drankCaffeine-30<0))
                    {
                        drankCaffeine -= 30;
                    }                  
                }
            }

            string result = energyDrinks.Any() ? $"Drinks left: {string.Join(", ", energyDrinks)}" : "At least Stamat wasn't exceeding the maximum caffeine.";

            Console.WriteLine(result);
            Console.WriteLine($"Stamat is going to sleep with {drankCaffeine} mg caffeine.");
        }
    }
}
