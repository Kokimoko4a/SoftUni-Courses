using System;
using System.Linq;

namespace _4._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i <rotations; i++)
            {
                int tempEl = numbers[0];

                for (int k = 0; k < numbers.Length-1; k++)
                {
                    numbers[k] = numbers[k+1] ;
                    numbers[k+1] = tempEl ;
                }
            }

            Console.WriteLine(String.Join (" ", numbers));
        }
    }
}
