using System;

namespace P04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int mechosCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double puzzlesPrice = puzzlesCount * 2.60;
            double dollsPrice = dollsCount * 3;
            double mechosPrice = mechosCount * 4.10;
            double minoinsPrice = minionsCount * 8.20;
            double trucksPrice = trucksCount * 2;

            double totalToysPrice = puzzlesPrice + dollsPrice + mechosPrice + minoinsPrice + trucksPrice;

            int totalToysCount = puzzlesCount + dollsCount + mechosCount + minionsCount + trucksCount;


            if (totalToysCount  >=50)
            {
                double discount = totalToysPrice * 0.25;
                totalToysPrice -= discount; 
            }

            double rentPrice = totalToysPrice * 0.10;
            totalToysPrice -= rentPrice;

            if (totalToysPrice>= tripPrice )
            {
                double moneyLeft = totalToysPrice - tripPrice;
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else
            {
                double moneyMoreNeeded = tripPrice - totalToysPrice;
                Console.WriteLine($"Not enough money! {moneyMoreNeeded:f2} lv needed.");
            }
        }
    }
}
