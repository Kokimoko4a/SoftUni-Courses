using System;

namespace P06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double nailonCount = double.Parse(Console.ReadLine());
            double paintLitar = double.Parse(Console.ReadLine());
            double rasrediteLitar = double.Parse(Console.ReadLine());
            double hoursMaistori = double.Parse(Console.ReadLine());
            double nailonPrice = (nailonCount + 2) * 1.50;
            double dopalnitelnoPaint = paintLitar  * 0.1;
            double paintPrice = (paintLitar + dopalnitelnoPaint) * 14.5;
            double rasreditelPrice = rasrediteLitar * 5.00;

            double sumWithoutTrud = nailonPrice + paintPrice + rasreditelPrice + 0.4;
            double trud = sumWithoutTrud * 0.3;
            double trudPrice = trud * hoursMaistori;
            double sumWithTrud = sumWithoutTrud + trudPrice;

            Console.WriteLine(sumWithTrud);


            
        }
    }
}
