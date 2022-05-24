using System;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // ((daysInMonth * capsulesCount) * pricePerCapsule)
            int orders = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 1; i <= orders ; i++)
            {
                int days = int.Parse(Console.ReadLine());
                double priceCapsule = double.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                double price = (days * capsulesCount) * priceCapsule;
                sum += price;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${sum:f2}");

             
        }
    }
}
