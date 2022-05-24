using System;

namespace P06._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double metres = double.Parse(Console.ReadLine());
            double timePerOneMeter = double.Parse(Console.ReadLine());
            double timeNeeded = metres * timePerOneMeter;
            double zabavyane =  Math.Floor(metres / 15);
            double zabavyane2 = zabavyane * 12.5;
           
            double finalTime = timeNeeded + zabavyane2;
            if (finalTime < worldRecord) {

                Console.WriteLine($" Yes, he succeeded! The new world record is {finalTime:f2} seconds.");
            }

            else if (finalTime >=worldRecord )
            {
                double timeNeeded2 = finalTime - worldRecord;
                Console.WriteLine($"No, he failed! He was {timeNeeded2:f2} seconds slower.");
            }
        }
    }
}
