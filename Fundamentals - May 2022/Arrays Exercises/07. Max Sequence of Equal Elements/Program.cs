using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] theBest = new int[input.Length];
            int counter = 0;
            int copyCounter = 0;
            int theBestCount = 0;
            int theBestPosition = 0;

            for (int i = 0; i < input.Length; i++)
            {
                counter = 0;

                for (int k = i + 1; k < input.Length; k++)
                {
                    if (input[i] == input[k])
                    {
                        counter++;
                    }

                    else
                    {
                        break;
                    }
                }

                if (counter > copyCounter)
                {
                    theBestCount = counter;
                    theBestPosition = input[i];
                    copyCounter = counter;

                }             
            }

            for (int i = 0; i < theBestCount + 1; i++)
            {
                Console.Write($"{theBestPosition} ");
            }
        }
    }
}
