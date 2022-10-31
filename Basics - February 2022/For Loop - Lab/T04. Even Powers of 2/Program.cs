using System;

namespace T04._Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = 1;
            for (int counter = 0; counter <=number ; counter+=2)
            {
                Console.WriteLine(num);
                num = num * 2 * 2;
            }
        }
    }
}
