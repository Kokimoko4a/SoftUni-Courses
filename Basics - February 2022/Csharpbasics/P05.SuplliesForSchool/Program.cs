using System;

namespace P05.SuplliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
           double pencilPacket = double.Parse(Console.ReadLine());
            double markerPacket = double.Parse(Console.ReadLine());
            double preparatLitar = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double sumWithoutDiscount = pencilPacket * 5.80 + markerPacket * 7.20 + preparatLitar * 1.20;
            double discountSum = sumWithoutDiscount * discount / 100;
            double sumWithDiscount = sumWithoutDiscount - discountSum;
            Console.WriteLine(sumWithDiscount);

        }

    }
}
