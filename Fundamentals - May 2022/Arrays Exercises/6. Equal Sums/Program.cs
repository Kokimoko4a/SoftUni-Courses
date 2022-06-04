using System;
using System.Linq;

namespace _6._Equal_Sums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length ==1)
                {
                    Console.WriteLine(0);
                    return;
                }
                leftSum = 0;
                for (int left = i; left > 0; left--)
                {
                    int nextNumberPosition = left - 1;
                    if (left > 0)
                    {
                        leftSum += numbers[nextNumberPosition];
                    }

                }
                rightSum = 0;
                for (int right = i; right < numbers.Length; right++)
                {

                    int numberPosition = right + 1;
                    if (right < numbers.Length - 1)
                    {
                        rightSum += numbers[numberPosition];
                    }

                }

                if (leftSum ==rightSum )
                {
                    Console.WriteLine(i);
                    return;
                }

            }

            Console.WriteLine("no");
        }
    }
}
