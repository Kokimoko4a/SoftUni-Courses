using System;

namespace _03.New_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double priceperRose = 5;
            double priceperDalia = 3.8;
            double priceperLale = 2.8;
            double priceperNarcis = 3;
            double priceperGladiola = 2.5;
            double priceRose = flowerCount * priceperRose;
            double priceDalia = flowerCount * priceperDalia;
            double priceLale = flowerCount * priceperLale;
            double priceNarcis = flowerCount * priceperNarcis;
            double priceGladiola = flowerCount * priceperGladiola;

            if (flowerType == "Roses") {
                if (flowerCount > 80)
                {
                    priceRose = priceRose - priceRose * 10 / 100;
                }

                if (priceRose <= budget) {
                    double moneyLeft = budget - priceRose;
                    Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {moneyLeft:f2} leva left.");
                }

                else if (priceRose >budget )
                {
                    double moneyNeeded = priceRose - budget;
                    Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
                }
               
            }

            else if (flowerType == "Dahlias") {
                if (flowerCount > 90)
                {
                    priceDalia = priceDalia - priceDalia * 15 / 100;

                }
                if (priceDalia <= budget)
                {
                    double moneyLeft = budget - priceDalia;
                    Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {moneyLeft:f2} leva left.");
                }

                else if (priceDalia > budget)
                {
                    double moneyNeeded = priceDalia - budget;
                    Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
                }
            }

            else if (flowerType == "Tulips") {
                if (flowerCount > 80)
                {
                    priceLale = priceLale - priceLale * 15 / 100;
                }

                if (priceLale <= budget)
                {
                    double moneyLeft = budget - priceLale;
                    Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {moneyLeft:f2} leva left.");
                }

                else if (priceLale > budget)
                {
                    double moneyNeeded = priceLale - budget;
                    Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
                }

            }

            else if (flowerType == "Narcissus") {
             if (flowerCount < 120)
                {
                    priceNarcis = priceNarcis + priceNarcis * 15 / 100;
                }

                if (priceNarcis <= budget)
                {
                    double moneyLeft = budget - priceNarcis;
                    Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {moneyLeft:f2} leva left.");
                }

                else if (priceNarcis > budget)
                {
                    double moneyNeeded = priceNarcis - budget;
                    Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
                }
            }


            else if (flowerType == "Gladiolus")
            { if ( flowerCount < 80)
                {
                    priceGladiola = priceGladiola + priceGladiola * 20 / 100;
                }

                if (priceGladiola  <= budget)
                {
                    double moneyLeft = budget - priceGladiola;
                    Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {moneyLeft:f2} leva left.");
                }

                else if (priceGladiola > budget)
                {
                    double moneyNeeded = priceGladiola - budget;
                    Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
                }
            }


         


        }
    }
}
