using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfGroups = int.Parse(Console.ReadLine());
            int sum = 0;
            int peoplesInGroup = 0;
            double musalaCount=0;
            double monblanCount = 0;
            double kilimandgaroCount = 0;
            double K2Count = 0;
            double everestCount = 0;

            for (int i = 1; i <= countOfGroups; i++)
            {
                peoplesInGroup = int.Parse(Console.ReadLine());
               sum += peoplesInGroup;
                if (peoplesInGroup <5 || peoplesInGroup ==5)
                {
                    musalaCount+=peoplesInGroup;
                }

                else if (peoplesInGroup >= 6 && peoplesInGroup <= 12)
                {
                    monblanCount+=peoplesInGroup;
                }

              else  if (peoplesInGroup >= 13 && peoplesInGroup <= 25)
                {
                    kilimandgaroCount+=peoplesInGroup;
                }

                else if (peoplesInGroup >= 26 && peoplesInGroup <= 40)
                {
                    K2Count+=peoplesInGroup;
                }

               else if (peoplesInGroup >= 41)
                {
                    everestCount+=peoplesInGroup;
                }
            }

           double percentsMusala = musalaCount  / sum * 100;
            double percentsMonblan  = monblanCount   / sum * 100;
            double percentsKilimandgaro  = kilimandgaroCount   / sum * 100;
            double percentsK2 = K2Count   / sum * 100;
            double percentsEverest  = everestCount   / sum * 100;

            Console.WriteLine($"{percentsMusala:f2}%");
            Console.WriteLine($"{percentsMonblan:f2}%");
            Console.WriteLine($"{percentsKilimandgaro:f2}%");
            Console.WriteLine($"{percentsK2:f2}%");
            Console.WriteLine($"{percentsEverest:f2}%");
        }
    }
}
