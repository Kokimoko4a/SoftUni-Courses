using System;
using System.Linq;
namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfInputs = int.Parse(Console.ReadLine());
            string[] input = new string[numbersOfInputs];
            int[] codedArr = new int[numbersOfInputs];

            for (int i = 0; i < input.Length; i++)
            {
                int sumVowels = 0;
                int sumConsonants = 0;
                int final = 0;

                input[i] = Console.ReadLine();

                foreach (char item in input[i])
                {
                    if ("aeoiuAEOIU".Contains(item))
                    {
                        sumVowels += (int)item * input[i].Length;
                    }

                    else
                    {
                        sumConsonants += (int)item / input[i].Length;
                    }
                }

                final = sumConsonants + sumVowels;
                codedArr[i] = final;
            }

            Array.Sort(codedArr);

            foreach (var item in codedArr)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}

