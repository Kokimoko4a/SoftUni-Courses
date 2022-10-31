using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] numbers = new string[count];
           
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Console.ReadLine();
              
            }

            for (int i = numbers.Length-1 ; i >=0; i--)
            {
                Console.Write($"{numbers[i]} ");

            }

        }
    }
}
