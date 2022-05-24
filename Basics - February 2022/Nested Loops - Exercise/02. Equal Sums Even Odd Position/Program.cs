using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int currNum = start ; currNum <= end; currNum++)
            {
                int evenSum = 0;
                int oddSum = 0;
                int digitPosition = 6;
                int currNum2 = currNum;
                
                while (currNum2 >0)
                {

                    int currDigit = currNum2 % 10;
                    currNum2 = currNum2 / 10; 
                    
                    if (digitPosition  % 2 == 0)
                    {
                        evenSum += currDigit ;
                    }

                    else
                    {
                        oddSum += currDigit ;
                    }

                    digitPosition--;
                }

                if (oddSum == evenSum )
                {
                    Console.Write(currNum + " ");
                }
            }
        }
    }
}
