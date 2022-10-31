using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double min = double.MaxValue;

            while (input != "Stop")
            {
                double inputAsNumber = double.Parse(input);
                if (inputAsNumber < min)
                {
                    min = inputAsNumber;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(min);
        }
    }
}
