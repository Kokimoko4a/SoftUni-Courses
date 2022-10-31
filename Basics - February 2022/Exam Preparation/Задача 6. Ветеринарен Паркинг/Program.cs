using System;

namespace Задача_6._Ветеринарен_Паркинг
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double dayTax = 0;
            double total = 0;

            for (int day = 1; day <= days; day++)
            {
                for (int hour = 1; hour <= hours; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        dayTax += 2.5;
                    }

                    else if (day%2!=0 && hour %2==0)
                    {
                        dayTax += 1.25;
                    }

                    else
                    {
                        dayTax += 1;
                    }

                }

                Console.WriteLine($"Day: {day} - {dayTax:f2} leva");
                total += dayTax;
                dayTax = 0;
            }

            Console.WriteLine($"Total: {total:f2} leva");



        }
    }
}
