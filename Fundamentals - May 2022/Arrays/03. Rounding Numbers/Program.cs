using System;
using System.Linq;
namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                double copy = nums[i];
                copy = (int)Math.Round(copy,MidpointRounding.AwayFromZero );
                Console.WriteLine($"{nums[i]} => {copy}");
            }


        }
    }
}
