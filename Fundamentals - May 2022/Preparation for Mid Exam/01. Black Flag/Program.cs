using System;

namespace _01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double targetPlunder = double.Parse(Console.ReadLine());
            double total = 0;


            for (int i = 1; i <= days; i++)
            {
                total += dailyPlunder;

                if (i % 3 == 0)
                {
                    total += 0.5 * dailyPlunder;
                }

                if (i % 5 == 0)
                {
                    total -= 0.3 * total;
                }


            }

            if (total >=targetPlunder )
            {
                Console.WriteLine($"Ahoy! {total:f2} plunder gained.");
            }

            else if (total <targetPlunder )
            {
                double percentage = total / targetPlunder * 100;


                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
