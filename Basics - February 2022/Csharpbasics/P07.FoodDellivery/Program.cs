using System;

namespace P07.FoodDellivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenuCount = int.Parse(Console.ReadLine ());
            int fishMenuCount = int.Parse(Console.ReadLine());
            int vegetarianMenuCount = int.Parse(Console.ReadLine());
            double sumWithoutDeliveryAndDesert = chickenMenuCount * 10.35 + fishMenuCount * 12.40 + vegetarianMenuCount * 8.15 ;
            double desert = sumWithoutDeliveryAndDesert * 0.20;
            double sumWithoutDelivery = sumWithoutDeliveryAndDesert + desert;
            double sumWithDelivery = sumWithoutDelivery + 2.50;
            Console.WriteLine(sumWithDelivery);
        }
    }
}
