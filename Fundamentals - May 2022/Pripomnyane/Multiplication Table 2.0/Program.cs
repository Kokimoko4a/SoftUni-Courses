using System;

namespace Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int i = int.Parse(Console.ReadLine());
            int i2 = 0;

            if (i > 10)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
                return;
            }

            for (i2=i; i2 <= 10; i2++)
            {
                
                Console.WriteLine($"{num} X {i2} = {num * i2}");
            }
        }
    }
}
