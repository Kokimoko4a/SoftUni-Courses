using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfActor = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int countOfReviewers = int.Parse(Console.ReadLine());
            double sum = 0.0;
             
            for (int i = 1; i <= countOfReviewers ; i++)
            {
                string nameOfReviewers = Console.ReadLine();
                double pointFromOneReviewer = double.Parse(Console.ReadLine());
                
                int LenghtOfNameReviewers = nameOfReviewers.Length;

                sum  =+ pointsFromAcademy + (LenghtOfNameReviewers * pointFromOneReviewer/2);
                pointsFromAcademy = sum;             
                if (sum >= 1250.5)
                {
                    break;                    
                }               
            }

            if (sum < 1250.5)
            {
                double pointsNeeded = 1250.5 - sum;

                Console.WriteLine($"Sorry, {nameOfActor} you need {pointsNeeded:f1} more!");
            }

            else if (sum >= 1250.5)
            {
                Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {sum:f1}!");
            }
         

        }
    }
}
