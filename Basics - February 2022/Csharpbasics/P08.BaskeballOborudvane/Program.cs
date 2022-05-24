using System;

namespace P08.BaskeballOborudvane
{
    class Program
    {
        static void Main(string[] args)
        {
            int annualTax = int.Parse(Console.ReadLine());

            double sneakersPrice = annualTax - (annualTax * 0.4);
            double clothesPrice = sneakersPrice - (sneakersPrice * 0.2);
            double ballPrice = clothesPrice * 0.25;
            double acessoriesPrice = 0.2 * ballPrice;

            double totalPrice = annualTax + sneakersPrice + clothesPrice + ballPrice + acessoriesPrice;
            
            Console.WriteLine(totalPrice);
                

        }
    }
}
