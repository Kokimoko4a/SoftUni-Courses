using System;

namespace _4._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < nLines ; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int symbolInt = (int)symbol;
                sum += symbolInt;


            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
