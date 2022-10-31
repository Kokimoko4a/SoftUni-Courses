using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> gauss = new List<double>();


            for (int i = 0; i <  nums.Count  / 2; i++)
            {
                double gaussNumber = nums[i] + nums[nums.Count - 1 -i];
                gauss.Add(gaussNumber );
               
            }

            if (nums .Count %2!=0)
            {
                gauss.Add(nums[nums.Count / 2]);
            }

            Console.WriteLine(String.Join(" ", gauss ));
        }
    }
}
