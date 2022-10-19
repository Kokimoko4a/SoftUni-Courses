using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstsBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondsBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int> claimedItems = new List<int>();

            while (firstsBox.Count > 0 && secondsBox.Count > 0)
            {
                int currFirst = firstsBox.Peek();
                int currSecond = secondsBox.Pop();
                int sum = currSecond + currFirst;

                if (sum % 2 == 0)
                {
                    firstsBox.Dequeue();
                    claimedItems.Add(sum);
                }

                else
                {
                    firstsBox.Enqueue(currSecond);
                }
            }

            if (firstsBox.Count ==0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondsBox.Count==0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }

            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
