using System;

namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            int theBestCountOfLectures = 0;
            double max= int.MinValue;

            for (int i = 0; i < studentsCount ; i++)
            {
                int lecturesTaken = int.Parse(Console.ReadLine());

                //{ total bonus} = { student attendances} / { course lectures}    *(5 + { additional bonus})

                 double finalScore = (double)lecturesTaken / lecturesCount * (5 + additionalBonus);

                if (finalScore >max )
                {
                    max = finalScore;
                    theBestCountOfLectures = lecturesTaken;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling  (max)}.");
            Console.WriteLine($"The student has attended {theBestCountOfLectures } lectures.");
        }
    }
}
