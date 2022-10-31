using System;
using System.Linq;
namespace _8._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            int[] condensed = new int[nums.Length - 1];
            // int i = 0;

            while (condensed.Length != nums.Length / 2)
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == nums.Length - 1)
                    {
                        break;
                    }

                    condensed[i] = nums[i] + nums[i + 1];
                }

            nums = condensed;
        }
    }
}

