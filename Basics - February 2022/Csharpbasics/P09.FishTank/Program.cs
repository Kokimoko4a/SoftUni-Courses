using System;

namespace P09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double zaetostPercents = double.Parse(Console.ReadLine());

             double Area = length * width * height;
            double AreaInLitri = Area / 1000;
            double zaetostPlace = zaetostPercents / 100;
            double litriNeeded = AreaInLitri * (1 - zaetostPlace);
            Console.WriteLine(litriNeeded);

        }
    }
}
