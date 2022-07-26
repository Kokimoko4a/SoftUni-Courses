using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> firstRacer = new List<int>();
            List<int> secondRacer = new List<int>();

            int middle = input.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                firstRacer.Add(input[i]);
            }

            for (int i = input.Count - 1; i > middle; i--)
            {
                secondRacer.Add(input[i]);
            }

            double sumFirst = 0;
            double sumSecond = 0;

            foreach (var step in firstRacer)
            {
                if (step == 0)
                {
                    sumFirst = sumFirst * 0.8;
                }
                sumFirst += step;
                continue;

            }

            foreach (var step in secondRacer)
            {
                if (step == 0)
                {
                    sumSecond *= 0.8;
                    continue;
                }

                sumSecond += step;
            }

            string fisrtSumAsText = sumFirst.ToString();
            string secondSumAsText = sumSecond.ToString();

            if (sumFirst < sumSecond)
            {
                if (fisrtSumAsText.Contains("."))
                {
                    Console.WriteLine($"The winner is left with total time: {sumFirst:f1}");
                }

                else
                {
                    Console.WriteLine($"The winner is left with total time: {sumFirst:f0}");
                }
            }

            else
            {

                if (secondSumAsText.Contains("."))
                {
                    Console.WriteLine($"The winner is right with total time: {sumSecond:f1}");
                }

                else
                {
                    Console.WriteLine($"The winner is right with total time: {sumSecond:f0}");
                }
            }
        }
    }
}
