using System;
using System.Linq;

namespace _05._Longest_Increasing_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int .Parse ).ToArray();
            int[] seqence = new int[numbers.Length];
            int[] theBestSequence = new int[numbers.Length];

            int counter = 0;
            int theBestCount = 0;

            if (numbers .Length ==1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            for (int i = 0; i < numbers .Length ; i++)
            {
                counter = 0;
                seqence[0] = numbers[i];
                int r = 0;
                for (int k = i+1; k < numbers.Length-1; k++)
                {
                    if (numbers[i] <numbers[k])
                    {
                      
                        r++;
                        counter++;
                        int secondThing = numbers[k - 1];
                       // numbers[i] = numbers[k];                        
                        seqence[r] = numbers[k]; 
                        
                           
                    }

                }


                if (counter > theBestCount)
                {
                    theBestCount = counter;
                    theBestSequence = seqence;
                }
            }

            foreach (var item in theBestSequence )
            {
                if (item ==0)
                {
                    continue; 
                }

                else
                {
                    Console.Write(item + " ");
                }
            } 
        }
    }
}
