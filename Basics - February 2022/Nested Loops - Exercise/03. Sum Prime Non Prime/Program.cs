using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int primeSum = 0;
            int notPrime = 0; 

            while ((input = Console.ReadLine ()) != "stop")
            {
                int currNum = int.Parse(input);

                if (currNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                else if (currNum == 0)
                {
                    notPrime += currNum;
                    continue;
                }

                bool isPrime = true;

                for (int div = 2; div < currNum ; div++)
                {
                    if (currNum %div ==0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime )
                {
                    primeSum += currNum;
                }

                else
                {
                    notPrime += currNum;
                }

            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {notPrime}");
        }
    }
}
