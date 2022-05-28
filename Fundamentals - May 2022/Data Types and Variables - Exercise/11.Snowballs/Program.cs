using System;
using System.Numerics;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            BigInteger  numberOfSnowballs = BigInteger.Parse(Console.ReadLine());
            BigInteger  theBest = int.MinValue;
            BigInteger theSnow = 0;
            BigInteger theTime = 0;
            BigInteger theQuality = 0;

            for (int i = 0; i < numberOfSnowballs ; i++)
            {
                BigInteger snowballSnow = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime = BigInteger.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger  snowballValue = snowballSnow / snowballTime;
                snowballValue = BigInteger.Pow(snowballValue , snowballQuality ); 

                if (snowballValue > theBest )
                {
                    theBest = snowballValue;
                    theSnow = snowballSnow;
                    theTime = snowballTime;
                    theQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{theSnow} : {theTime} = {theBest} ({theQuality})");

        }
    }
}
