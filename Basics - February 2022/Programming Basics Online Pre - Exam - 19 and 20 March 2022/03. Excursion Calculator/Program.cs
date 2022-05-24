using System;

namespace _03._Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int humansCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double pricePerHuman = 0;

            if (humansCount <=5)
            {
                if (season =="spring")
                {
                    pricePerHuman = 50;
                }

               else if (season == "summer")
                {
                    pricePerHuman = 48.5;
                }

                else if (season == "autumn")
                {
                    pricePerHuman = 60;
                }

               else if(season == "winter")
                {
                    pricePerHuman = 86;
                }
            }

            else if (humansCount >5)
            {
                if (season == "spring")
                {
                    pricePerHuman = 48;
                }

                else if (season == "summer")
                {
                    pricePerHuman = 45;
                }

                else if (season == "autumn")
                {
                    pricePerHuman = 49.5;
                }

                else if (season == "winter")
                {
                    pricePerHuman = 85;
                }
            }

           double totalProsto = pricePerHuman * humansCount;

            if (season == "summer")
            {
                totalProsto -= totalProsto * 0.15;
            }

            else if (season == "winter")
            {
                totalProsto += totalProsto * 0.08;
            }

            Console.WriteLine($"{totalProsto:f2} leva.");

       }
    }
}
