using System;

namespace ozelenyavane
{
    class Program
    {
        static void Main(string[] args)
        {
            double KvMetri = double.Parse(Console.ReadLine());
            double CenaNaKv = 7.61;
            double CenaBezNamalenie = KvMetri * CenaNaKv;
            double Namalenie = CenaBezNamalenie * 0.18;
            double kraina = CenaBezNamalenie - Namalenie;
            Console.WriteLine($"The final price is: {kraina} lv.");
            Console.WriteLine($"The discount is: {Namalenie} lv.");


        }
    }
}
