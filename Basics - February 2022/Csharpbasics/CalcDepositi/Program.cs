using System;

namespace CalcDepositi
{
    class Program
    {
        static void Main(string[] args)
        {
            double depozitSum = double.Parse(Console.ReadLine());
            int srokDepozit = int.Parse(Console.ReadLine());
            double lihvaYear = double.Parse(Console.ReadLine());
            double lihva = depozitSum * lihvaYear / 100;
            double lihvaMonth = lihva / 12;
            double sum = depozitSum + srokDepozit * lihvaMonth;
            Console.WriteLine(sum);

        }
    }
}
