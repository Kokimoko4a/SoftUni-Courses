using System;

namespace Sum_of_odd_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int i = 1;
            int count = 0;

            while (count !=number)
            {
                if (i%2!=0)
                {
                    Console.WriteLine(i);
                    sum += i;
                    count++;
                }
                
                i++;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
