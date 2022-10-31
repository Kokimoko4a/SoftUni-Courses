using System;

namespace strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int strongNumber = int.Parse(Console.ReadLine());
            int numberCopy = strongNumber; 
            int sum = 0;

            while (strongNumber>0)
            {
                int factorialNumber = 1;
                int currNum = strongNumber % 10;
                strongNumber  /= 10;

                for (int i = 2; i <= currNum ; i++)
                {
                    factorialNumber *= i;
                }

                sum += factorialNumber;

            }

            Console.WriteLine(sum==numberCopy ? "yes" : "no");
        }
    }
}
