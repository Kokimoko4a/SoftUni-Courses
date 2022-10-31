using System;

namespace _02._Football_Kit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double targetSumBall = double.Parse(Console.ReadLine());
            double shortsPrice = tshirtPrice * 0.75;
            double socketsPrice = shortsPrice * 0.2;
            double shoes = 2 * (tshirtPrice + shortsPrice);
            double totalBezNamalenie = tshirtPrice + shortsPrice + socketsPrice + shoes;
            double discount = totalBezNamalenie * 0.15;
            double total = totalBezNamalenie - discount;

            if (total >=targetSumBall )
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {total:f2} lv.");
            }

            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {targetSumBall -total:f2} lv. more.");
            }
            
        }
    }
}
