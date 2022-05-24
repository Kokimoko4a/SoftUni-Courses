using System;

namespace _05.MoneyBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            string input = Console.ReadLine();


            while (input !="NoMoreMoney")
            {
                double inputAsNumber = double.Parse(input);
                if (inputAsNumber <0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {inputAsNumber:f2}");
                total += inputAsNumber;
                input = Console.ReadLine();



            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
