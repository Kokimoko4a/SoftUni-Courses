using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                sum += currNum;
                if (currNum > max)
                {
                    max = currNum;
                }            

            }
            sum -= max;
            if (sum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }

            else
            {
                int diff = Math.Abs(max - sum);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
