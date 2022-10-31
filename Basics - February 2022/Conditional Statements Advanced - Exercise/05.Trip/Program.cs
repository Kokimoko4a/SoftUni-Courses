using System;

namespace _05.Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double rent = 0;
            string typeVacation = String.Empty;

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    rent = 0.3 * budget;
                    typeVacation = "Camp";
                }

                else if (season == "winter")
                {
                    rent = 0.7 * budget;
                    typeVacation = "Hotel";
                }
                Console.WriteLine("Somewhere in Bulgaria");
                Console.WriteLine($"{typeVacation} - {rent:f2}");
            }

            else if (budget <=1000)
            {
                if (season == "summer")
                {
                    rent = 0.4 * budget;
                    typeVacation = "Camp";
                }

                else if (season == "winter")
                {
                    rent = 0.8 * budget;
                    typeVacation = "Hotel";
                }
                Console.WriteLine("Somewhere in Balkans");
                Console.WriteLine($"{typeVacation} - {rent:f2}");
            }

            else if (budget >1000)
            {
                if (season == "summer")
                {
                    rent = 0.9 * budget;
                    typeVacation = "Hotel";
                }

                else if (season == "winter")
                {
                    rent = 0.9 * budget;
                    typeVacation = "Hotel";
                }
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"{typeVacation} - {rent:f2}");
            }

        }
    }
}
