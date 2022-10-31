using System;

namespace P05._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statistiCount = int.Parse(Console.ReadLine());
            double clothePerStat = double.Parse(Console.ReadLine());
            double PriceClothes = statistiCount * clothePerStat;
            double dekorPrice = 0.1 * budget;
            if (statistiCount > 150) {

                double discount = PriceClothes * 0.1;
                PriceClothes = PriceClothes - discount;
            }

            double FinalPrice = PriceClothes + dekorPrice;
            if (FinalPrice > budget)
            {
                Console.WriteLine("Not enough money!");
                double moneyNeeded = FinalPrice - budget;
                Console.WriteLine($"Wingard needs {moneyNeeded:f2} leva more.");

            }
            else if (FinalPrice <= budget) {

                Console.WriteLine("Action!");
                double moneyLeft = budget - FinalPrice ;
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }


        }
    }
}
