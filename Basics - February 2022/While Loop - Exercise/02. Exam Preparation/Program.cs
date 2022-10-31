using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGradesMaxCnt = int.Parse(Console.ReadLine());
            string taskName;
            int solvedTasks = 0;
            int badGradesCnt = 0;
            int sum = 0;
            string lastTask = string.Empty;

            while ((taskName =Console.ReadLine ()) != "Enough")
            {
                int gradeTask = int.Parse(Console.ReadLine());

                if (gradeTask <=4)
                {
                    badGradesCnt++;

                    if (badGradesMaxCnt <= badGradesCnt)
                    {
                        break;
                    }
                }

               

                solvedTasks++;
                sum += gradeTask;
                lastTask = taskName;
            }

            if (badGradesCnt >=badGradesMaxCnt )
            {
                Console.WriteLine($"You need a break, {badGradesCnt} poor grades.");
            }

            else
            {
                double avgGrade = (double)sum / solvedTasks;
                Console.WriteLine($"Average score: {avgGrade:f2}");
                Console.WriteLine($"Number of problems: {solvedTasks}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
        }
    }
}
