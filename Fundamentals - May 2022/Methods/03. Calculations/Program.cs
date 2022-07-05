using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // On the first line – a string – "add", "multiply", "subtract", "divide".

            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                Add (num1, num2);
            }

            else if (command == "multiply")
            {
                Multiply(num1, num2);
            }

            else if (command == "subtract")
            {
                Subtract(num1, num2);
            }

            else
            {
                Divide(num1, num2);
            }
        }

        private static void Divide(int num1, int num2)
        {
            Console.WriteLine(num1 /num2 );
        }

        private static void Subtract(int num1, int num2)
        {
            Console.WriteLine(num1 -num2 );
        }

        private static void Multiply(int num1, int num2)
        {
            Console.WriteLine(num2 *num1 );
        }

        private static void Add (int num1, int num2)
        {
            Console.WriteLine(num1 +num2 );
        }
    }
}
