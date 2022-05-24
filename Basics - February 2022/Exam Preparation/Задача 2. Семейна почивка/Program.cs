using System;

namespace Задача_2._Семейна_почивка
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int sleeps = int.Parse(Console.ReadLine());
            double pricePerSleep = double.Parse(Console.ReadLine());
            int percentsForTapotii = int.Parse(Console.ReadLine());


            if (sleeps >7)
            {
                pricePerSleep -= pricePerSleep * 0.05;
                
            }

            double moneyForHotel = pricePerSleep * sleeps;
            double moneyForSmth = budget * percentsForTapotii / 100;
            double total = moneyForHotel + moneyForSmth;
            double diff = Math.Abs(total - budget);

            if (total <=budget )
            {
                Console.WriteLine($"Ivanovi will be left with {diff:f2} leva after vacation.");
            }

            else
            {
                Console.WriteLine($"{diff:f2} leva needed."); 
            }






        }
    }
}
