using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double avrageGrade = 0;
            double badGrades = 0;
            double sumGrades = 0;
            int counterGrade = 1;
            double currentgrade = double.Parse(Console.ReadLine());
            while (counterGrade<=12)
            {
               

                if (currentgrade <4.00)
                {
                 currentgrade = double.Parse(Console.ReadLine());
                    badGrades++;
                    if (badGrades == 2)
                    {
                        Console.WriteLine("Skasan si");
                    }
                }

                else
                {
                    counterGrade++;
                    sumGrades += currentgrade;
                }
                
            }
            avrageGrade = sumGrades /12
                Console.WriteLine(  );

        }
    }
}
