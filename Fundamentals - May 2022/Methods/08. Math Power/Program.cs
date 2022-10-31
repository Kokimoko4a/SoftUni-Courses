using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(PoweredNum(number, power));  
        }

        private static double  PoweredNum(double number, double power)
        {
            double final = 1;

            for (int i = 0; i < power ; i++)
            {
               final  *= number;
               
            }

            return final ;
        }
    }
}
