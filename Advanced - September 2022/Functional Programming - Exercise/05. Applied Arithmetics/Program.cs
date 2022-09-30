using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i]++;
                }
                return nums;
            };

            Func<int[], int[]> subtract = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i]--;
                }
                return nums;
            };

            Func<int[], int[]> multiply = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i]*=2;
                }
                return nums;
            };


            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        add(numbers);
                        break;

                    case "subtract":
                        subtract(numbers);
                        break;

                    case "multiply":
                        multiply(numbers);
                        break;

                    case "print":
                        Console.WriteLine(String.Join(" ",numbers));
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
