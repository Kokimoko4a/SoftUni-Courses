using System;

namespace _10.Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int pokePowerOriginal = pokePower;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int countofPokes = 0;

            while (pokePower >=distance )
            {
                pokePower -= distance;
                countofPokes++;

                if (pokePower == pokePowerOriginal*0.5 && exhaustionFactor !=0 )
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(countofPokes);
        }
    }
}
