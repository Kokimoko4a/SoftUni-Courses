using System;

namespace _7._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CAPACITY = 255;
            int capacityCopy = 0 ;
            int nLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < nLines ; i++)
            {
                int inputWater = int.Parse(Console.ReadLine());
                if (inputWater +capacityCopy >CAPACITY )
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                
                    capacityCopy += inputWater;
                 
                
            }
            Console.WriteLine(capacityCopy );
        }
    }
}
