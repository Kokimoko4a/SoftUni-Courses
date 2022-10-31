using System;
using System.Linq;

namespace _5._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isTopInteger = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    Console.Write($"{numbers[i]} ");
                    return; 
                }

                for (int k = i+1; k < numbers.Length; k++)
                {
                    if (numbers[i] <= numbers[k])
                    {                       
                        isTopInteger = false;
                        break;
                    }

                    else
                    {
                        isTopInteger = true;
                    }
                    

                }

                if(isTopInteger )
                {
                    Console.Write($"{numbers[i]} ");
                }

                



            }
        }
    }
}
