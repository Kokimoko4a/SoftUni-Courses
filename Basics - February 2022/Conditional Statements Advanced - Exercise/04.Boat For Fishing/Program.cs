using System;

namespace _04.Boat_For_Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());
            double money = 0;

            switch (season)
            {
                case "Spring":
                    money = 3000;
                    break;

                case "Summer":
                case "Autumn":
                    money = 4200;
                    break;

                case "Winter":
                    money = 2600;
                    break;

                default:
                    break;
            }

            if (fisherman <=6)
            {
                double discount = 0.1 * money;
                money -= discount;
            }

            else if (fisherman <=11)
            {
                double discount = 0.15 * money;
                money -= discount;
            }

            else
            {
                double discount = 0.25 * money;
                money -= discount;
            }

            if (fisherman % 2 == 0 && season != "Autumn") {               
                    double discount = money * 0.05;
                    money -= discount;               
            }

            if (budget >= money) {
                double moneyLeft = budget - money;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }

            else
            {
                double moneNeeded = money - budget;
                Console.WriteLine($"Not enough money! You need {moneNeeded:f2} leva.");
            }
        }
    }
}
