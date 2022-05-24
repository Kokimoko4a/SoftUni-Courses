using System;

namespace _1to10
{
    class Program
    {
        static void Main(string[] args)
        {
            int countFoodOfDog = int.Parse(Console.ReadLine());
            int countOfCatFood = int.Parse(Console.ReadLine());
            double priceperdogfood = 2.50;
            double prisepercatfood = 4;
            double sum = countFoodOfDog * priceperdogfood + countOfCatFood * prisepercatfood;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
