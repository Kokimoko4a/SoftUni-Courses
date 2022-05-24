using System;

namespace Задача_1._PC_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double procesorPriceDollars = double.Parse(Console.ReadLine());
            double videoCardPriceDollars = double.Parse(Console.ReadLine());
            double ramPriceDollars = double.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double procesorLeva = procesorPriceDollars * 1.57;
            double videoCardLeva = videoCardPriceDollars  * 1.57;
            double ramLeva = ramPriceDollars  * 1.57;
            double ramFinalPrice = ramLeva  * ramCount ;
            procesorLeva = procesorLeva - (procesorLeva * discount );
            videoCardLeva = videoCardLeva - (videoCardLeva * discount);

            double total = procesorLeva + videoCardLeva + ramFinalPrice;
            Console.WriteLine($"Money needed - {total:f2} leva.");
            


        }
    }
}
