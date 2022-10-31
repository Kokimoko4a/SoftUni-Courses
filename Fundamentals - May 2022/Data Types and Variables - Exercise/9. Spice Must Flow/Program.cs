using System;

namespace _9._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int POWER = 100;
            const int SPICESFORWORKERS = 26;
            const int DAMAGE = 10;
            int startingYeild = int.Parse(Console.ReadLine());
            int daysOperated = 0;
            int totalSpicesSum = 0;
            
            while (startingYeild >= POWER )
            {
              totalSpicesSum +=  startingYeild - SPICESFORWORKERS ;
                startingYeild  -= DAMAGE;
                daysOperated++;

                if (startingYeild <POWER )
                {
                    totalSpicesSum -= SPICESFORWORKERS;
                } 
            }
           

              
            Console.WriteLine(daysOperated);
            Console.WriteLine(totalSpicesSum);
        }
    }
}
