using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int smallNumber = int.Parse(Console.ReadLine());

            if (smallNumber == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int remainder = 0;
            StringBuilder sumReversed = new StringBuilder();
            StringBuilder sumNormal = new StringBuilder();

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int currSum = 0;
                string currDigit = bigNumber[i].ToString();
                int realyDigit = int.Parse(currDigit);
                currSum = realyDigit * smallNumber + remainder;
                sumReversed.Append(currSum % 10);
                remainder = currSum / 10;

            }

            if (remainder != 0)
            {
                sumReversed.Append(remainder);
            }

            for (int i = sumReversed.Length - 1; i >= 0; i--)
            {
                sumNormal.Append(sumReversed[i]);
            }

            Console.WriteLine(sumNormal);
        }
    }
}
