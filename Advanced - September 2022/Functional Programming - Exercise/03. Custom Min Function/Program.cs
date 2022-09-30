using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = nums =>
            {
                int d = int.MaxValue;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i]< d)
                    {
                        d = nums[i];
                    }
                }
                return d;
            };

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(min(numbers));
        }
    }
}
