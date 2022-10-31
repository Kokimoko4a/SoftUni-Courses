using System;

namespace P03._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 15;
            if (minutes >= 60) {

                hour += 1;
                minutes -= 60;
               
            }
            if (hour>=24)
            {
                hour -= 24;
            }
            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
