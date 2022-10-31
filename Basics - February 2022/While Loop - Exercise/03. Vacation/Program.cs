using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripCost = double.Parse(Console.ReadLine());
            double avaibleMoney = double.Parse(Console.ReadLine());
            int seqSpendDaysCnt = 0;
            int totalDaysCnt = 0;
           

            while (avaibleMoney <tripCost )
            {
                totalDaysCnt++;
                string action = Console.ReadLine();
                double actionMoney = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    avaibleMoney -= actionMoney;

                    if (avaibleMoney <0)
                    {
                        avaibleMoney = 0;
                    }
                    seqSpendDaysCnt++;

                    if (seqSpendDaysCnt >=5)
                    {
                        break;
                    }
                }

                else if (action == "save")
                {
                    avaibleMoney += actionMoney;
                    seqSpendDaysCnt = 0;
                }
            }

            if (seqSpendDaysCnt >=5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(totalDaysCnt);
            }

            else
            {
                Console.WriteLine($"You saved the money for {totalDaysCnt} days.");
            }






        }
    }
}
