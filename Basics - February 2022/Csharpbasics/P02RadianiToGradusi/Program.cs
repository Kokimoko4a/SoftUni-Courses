using System;

namespace P02RadianiToGradusi
{
    class Program
    {
        static void Main(string[] args)
        {
            double radiani = double.Parse(Console.ReadLine());
            double graduci = radiani * 180 / Math.PI;
            Console.WriteLine(graduci);

        }
    }
}
