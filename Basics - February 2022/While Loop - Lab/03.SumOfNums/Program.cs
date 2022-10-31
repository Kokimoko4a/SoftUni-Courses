using System;

namespace _03.SumOfNums
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Eneter you target sum:");
            int targetNum = int.Parse(Console.ReadLine());
            int sum = 0;
            while (sum < targetNum )
            {
               // Console.WriteLine("Enter your num baby:");
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);            

        }
    }
}
