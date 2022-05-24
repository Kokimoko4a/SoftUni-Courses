using System;

namespace P01._Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalSeconds = firstTime + secondTime + thirdTime;

            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (seconds <= 9)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds }");
            }


        }
    }
}
