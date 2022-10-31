using System;

namespace _02._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int firstNum = 1; firstNum <= 10; firstNum++)
            {
                for (int secNum = 1; secNum <= 10; secNum++)
                {
                    Console.WriteLine($"{firstNum} * {secNum} = {firstNum * secNum }");
                }
            }
        }
    }
}
