using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double max = double.MinValue;

            while (input != "Stop")
            {
                double inputAsNumber = double.Parse(input);
                if (inputAsNumber > max)
                {
                    max = inputAsNumber;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(max);
        }
    }
}
