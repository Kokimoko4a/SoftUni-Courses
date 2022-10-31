using System;

namespace T03._Numbers_1_N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int counter = 1; counter <= number; counter+=3)
            {
                Console.WriteLine(counter);
            }
        }
    }
}
