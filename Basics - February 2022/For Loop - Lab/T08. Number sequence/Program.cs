using System;

namespace T08._Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int index = 0; index < countOfInputs ; index++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max) {
                    max = num;
                }

                 if(num<min)
                {
                    min = num;
                }
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
