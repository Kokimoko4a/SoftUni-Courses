using System;

namespace _01._Experience_Gaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battles = int.Parse(Console.ReadLine());
            double total = 0;
            int battlesCount = 0;

            for (int i = 1; i <=battles  ; i++)
            {
                double temporaryExperience = double.Parse(Console.ReadLine());
                battlesCount++;


                if (i % 3 == 0)
                {
                    total += temporaryExperience + temporaryExperience * 0.15;

                }

                if (i%5==0)
                {
                    total += temporaryExperience - temporaryExperience * 0.10;
                }

                if (i % 15 == 0)
                {
                    total += temporaryExperience + temporaryExperience * 0.05;

                }

                else if (i%3!= 0 && i%5!=0 && i%15!=0)
                {
                    total += temporaryExperience;
                }

                if (total >=neededExperience )
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
                    return;

                }
                

            }

            if (total >= neededExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
                return;

            }

            else if (total < neededExperience)
            {

                Console.WriteLine($"Player was not able to collect the needed experience, {(neededExperience -total) :f2} more needed.");
            }

        }
    }
}
