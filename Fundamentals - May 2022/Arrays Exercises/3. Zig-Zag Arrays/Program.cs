using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            int[] even = new int[countOfLines ];
            int[] odd = new int[countOfLines ];


            for (int i = 0; i < countOfLines; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse ).ToArray();

                if (i%2==0)
                {
                    even[i] = numbers[0];
                    odd[i] = numbers[1];
                }

                else
                {
                    even[i] = numbers[1];
                    odd[i] = numbers[0];
                }

            }

            Console.Write(String.Join (" " , even ));
            Console.WriteLine();
            Console.Write(String.Join (" " , odd ));
        }
    }
}
