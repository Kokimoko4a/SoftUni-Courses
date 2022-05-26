using System;

namespace Town_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameTown = Console.ReadLine();
            long populationOfTown = long.Parse(Console.ReadLine());
            long areaOfTown = long.Parse(Console.ReadLine());
            Console.WriteLine($"Town {nameTown} has population of {populationOfTown} and area {areaOfTown} square km.");
        }
    }
}
