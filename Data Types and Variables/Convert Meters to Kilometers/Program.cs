using System;

namespace Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            double kilometres = meters / 1000;
            Console.WriteLine($"{kilometres:f2}");
        }
    }
}
