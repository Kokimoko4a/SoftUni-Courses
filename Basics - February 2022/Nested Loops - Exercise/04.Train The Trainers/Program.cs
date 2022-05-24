using System;

namespace _04.Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfJury = int.Parse(Console.ReadLine());
            string nameOfPresentation;
            double midGrade = 0;
            double midFinalGrade = 0;
            int counterOfGrades = 0;

            while ((nameOfPresentation = Console.ReadLine ())!="Finish")
            {
                for (int i = 1; i <= countOfJury ; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    midGrade += grade / countOfJury;          
                }

                midFinalGrade += midGrade;
                Console.WriteLine($"{nameOfPresentation} - {midGrade:f2}.");
                counterOfGrades++;
                midGrade = 0;   
            }

            midFinalGrade  = midFinalGrade / counterOfGrades;
            Console.WriteLine($"Student's final assessment is {midFinalGrade:f2}.");


        }
    }
}
