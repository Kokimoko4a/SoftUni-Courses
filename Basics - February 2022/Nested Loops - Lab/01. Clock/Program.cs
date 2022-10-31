using System;

namespace _01._Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hours = 0; hours <= 23; hours++)
            {
                for (int min = 0; min <= 59; min++)
                {
                    Console.WriteLine($"{hours}:{min}");
                    /*for (int seconds = 0; seconds <=59; seconds++)
                    {
                        Console.WriteLine($"{hours:d2}:{min:d2}:{seconds:d2}");
                    }*/ // това е за секунди pluginn maika

                }
            }
        }
    }
}
