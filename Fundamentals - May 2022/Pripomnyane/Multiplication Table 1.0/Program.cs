using System;

namespace Multiplication_Table_1._0
{
    internal class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <=10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num*i}");
            }
        }
    }
}
