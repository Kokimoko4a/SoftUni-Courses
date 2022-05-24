using System;

namespace _04._Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double kilometresFistDay = double.Parse(Console.ReadLine());
            double kilometres = 0;
            double kilometres2First = kilometresFistDay;
            double sum = 0;

            for (int day = 1; day <= days ; day++)
            {
                int  percents = int.Parse(Console.ReadLine());
                double realpercents = (double)percents /100 ;
                kilometres = kilometresFistDay + ( kilometresFistDay * realpercents);
                kilometresFistDay = kilometres;
                sum += kilometres;

            }

            if (sum + kilometres2First   >=1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling((sum+ kilometres2First) - 1000)} more kilometers!");
            }

            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000-(sum + kilometres2First))} more kilometers");
            }
        }
    }
}
