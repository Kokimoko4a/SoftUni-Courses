using System;

namespace Задача_5._Туристически_магазин
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string productName;
            double sum = 0;
            int counter = 0;
            int countOfAllProducts = 0;

            while ((productName = Console.ReadLine()) != "Stop")
            {                
                double productPrice = double.Parse(Console.ReadLine());
                counter++; 

                if (counter == 3) 
                {
                    counter = 0;
                    productPrice/=2;
                }
                 
                sum += productPrice;

                if (sum >budget )
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {Math.Abs(budget -sum):f2} leva!");
                    return;
                }

                countOfAllProducts++;
            }

            Console.WriteLine($"You bought {countOfAllProducts} products for {sum:f2} leva.");
        }
    }
}
