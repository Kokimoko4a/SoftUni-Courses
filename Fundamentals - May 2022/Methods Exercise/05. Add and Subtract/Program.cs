using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int result = Add(num1, num2);
            int final = Subtract(result, num3);
            Console.WriteLine(final );
        }

        private static int Subtract(int result, int num3)
        {
            return result - num3;
        }

        private static int Add(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }
    }
}
