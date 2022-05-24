using System;

namespace _07._Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCardsCount = int.Parse(Console.ReadLine());
            int procesorCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double priceperOneVideoCard = 250.00;
            double priceVideoCards = priceperOneVideoCard * videoCardsCount;
            double procesorPricePerOne = 0.35 * priceVideoCards;
            double procesorPrice = procesorPricePerOne * procesorCount;
            double pricePerOneRam = 0.1 * priceVideoCards;
            double priceRam = pricePerOneRam * ramCount;
            double finalPrice = priceVideoCards + procesorPrice + priceRam;

            if (videoCardsCount > procesorCount) {

                double discount = 0.15 * finalPrice;
                finalPrice -= discount;
            }
            if (finalPrice <= budget)
            {

                double moneyLeft = budget - finalPrice;
                Console.WriteLine($"You have {moneyLeft:f2} leva left!");
            }
            else if (finalPrice > budget)
            {

                double moneyNeeded = finalPrice - budget;
                Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva more!");
            }

        }
    }
}
