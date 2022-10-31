using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            Console.WriteLine(EvenOrOdd(number));
        }

        private static int EvenOrOdd(int number)
        {
            int copy = number;
            int sumEven = 0;
            int sumOdd = 0;

            while (copy > 0)
            {
              copy  = number   % 10;
                number   /= 10;

                if (copy % 2 == 0)
                {
                    sumEven += copy;
                }

                else if (copy % 2 != 0)
                {
                    sumOdd += copy;
                }
            }
            int result = sumEven * sumOdd;
            return result ;
        }
    }
}
