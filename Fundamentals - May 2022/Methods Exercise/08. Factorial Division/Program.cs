using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double fact1 =double.Parse(Console.ReadLine());
            double fact2 = int.Parse(Console.ReadLine());

           double result1 = FactorialDivision(fact1);
            double result2 = FactorialDivision(fact2);
            Console.WriteLine($"{(result1  /result2) :f2}");
        }

        private static double FactorialDivision(double number)
        {
            double result = 1;
            while (number != 1)
            {
                result  *= number;
                number --;
            }

           return result;
        }
    }
}
