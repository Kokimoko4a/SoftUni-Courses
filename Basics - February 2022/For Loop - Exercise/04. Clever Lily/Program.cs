using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double washerPrice = double.Parse(Console.ReadLine());
            int toysSinglePrice = int.Parse(Console.ReadLine());
            int toysCollected = 0;
            int moneyCollected = 0;

            for (int currAge = 1; currAge <= n; currAge++)
            {
                if (currAge %2!=0)
                {
                    toysCollected++;
                }

                else
                {
                    int moneyPresent = (currAge * 5)-1;
                    moneyCollected += moneyPresent;
                }
                
            }

            int toysSellPrice = toysCollected * toysSinglePrice;
            moneyCollected += toysSellPrice;

            if (moneyCollected >=washerPrice )
            {
                double moneyLeft = moneyCollected - washerPrice;
                Console.WriteLine($"Yes! {moneyLeft:f2}");
            }

            else
            {
                double needed = washerPrice - moneyCollected;
                Console.WriteLine($"No! {needed:f2}");
            }


        }
    }
}
