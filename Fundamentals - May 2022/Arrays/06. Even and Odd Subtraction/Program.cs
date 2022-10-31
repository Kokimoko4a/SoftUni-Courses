using System;
using System.Linq;
namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfEven = 0;
            int sumOfOdd = 0;  

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    sumOfEven += nums[i];
                }

                else
                {
                    sumOfOdd += nums[i];
                }
            }

            Console.WriteLine(sumOfEven - sumOfOdd );
        }
    }
}
