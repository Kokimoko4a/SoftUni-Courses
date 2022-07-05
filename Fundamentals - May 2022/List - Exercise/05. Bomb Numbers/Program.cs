using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombandItsPower = Console.ReadLine().Split().Select(int.Parse).ToList();

            int bomb = bombandItsPower[0];
            int bombPower = bombandItsPower[1];

            for (int i = 0; i < input .Count ; i++)
            {
                if (input[i] == bomb )
                {
                    for (int left = i - bombPower  ; left <= i + bombPower   ; left++)
                    {
                        int start = Math.Max(0, i - bombPower);
                        int end = Math.Min(input .Count -1, i + bombPower);

                        for (int k = start; k <=end; k++)
                        {
                            input[k] = 0; 
                        }
                    }
                }
            }

            int sum = 0;

            for (int i = 0; i < input .Count ; i++)
            {
                sum += input[i];
            }

            Console.WriteLine(sum);

        }
    }
}
