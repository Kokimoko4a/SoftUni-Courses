using System;

namespace P08._Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfSerial = Console.ReadLine();
            double epizodTime = double.Parse(Console.ReadLine());
            double breakTime = double.Parse(Console.ReadLine());
            double lunchTime = 0.125 * breakTime;
            double otdihTime = 0.25 * breakTime;
            double finalTime = breakTime - lunchTime - otdihTime;
            if (epizodTime <= finalTime) {
                double timeLeft = finalTime - epizodTime;
                Console.WriteLine($"You have enough time to watch {nameOfSerial} and left with {Math.Ceiling(timeLeft)} minutes free time.");

            }

            else if (epizodTime > finalTime )
            {
                double timeNeeded = epizodTime - finalTime;
                Console.WriteLine($"You don't have enough time to watch {nameOfSerial}, you need {Math.Ceiling(timeNeeded)} more minutes.");
            }
        }
    }
}
