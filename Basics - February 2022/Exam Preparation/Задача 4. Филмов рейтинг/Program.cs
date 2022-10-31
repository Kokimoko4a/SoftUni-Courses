using System;

namespace Задача_4._Филмов_рейтинг
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfFilms = int.Parse(Console.ReadLine());
            double rateTotal = 0;
            double bestRate = double.MinValue;
            double worstRate = double.MaxValue;
            string bestName = "";
            string worstName = "";

            for (int i = 1; i <= countOfFilms ; i++)
            {
                 string name = Console.ReadLine();
                double rate = double.Parse(Console.ReadLine());
                rateTotal += rate;

                if (rate > bestRate)
                {
                    bestRate = rate;
                    bestName = name;
                }

                else if (rate < worstRate)
                {
                    worstRate = rate;
                    worstName = name;
                }               
            }
            Console.WriteLine($"{bestName} is with highest rating: {bestRate:f1}");
            Console.WriteLine($"{worstName} is with lowest rating: {worstRate:f1}");
            Console.WriteLine($"Average rating: {rateTotal/countOfFilms:f1}");


        }
    }
}
