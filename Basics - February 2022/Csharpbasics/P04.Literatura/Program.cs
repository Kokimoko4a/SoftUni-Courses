using System;

namespace P04.Literatura
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesCount = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysCount = int.Parse(Console.ReadLine());

            int hoursNeeded = pagesCount / pagesPerHour;
            int hoursPerDay = hoursNeeded / daysCount;

            Console.WriteLine(hoursPerDay);
            
        }
    }
}
