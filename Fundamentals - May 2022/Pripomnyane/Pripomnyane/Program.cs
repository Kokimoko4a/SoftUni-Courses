using System;

namespace Pripomnyane
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            while (true)
            {
                if (number %2==0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    return;
                }

                else if (number %2!=0 || number ==0)
                {
                    Console.WriteLine("Please write an even number.");
                    number = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}

