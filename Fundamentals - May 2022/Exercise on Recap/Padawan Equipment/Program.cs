using System;

namespace Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double .Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceLightSaber = double .Parse(Console.ReadLine()); 
            double priceRobes = double .Parse(Console.ReadLine());  
            double priceBelts = double .Parse(Console.ReadLine());
            int freeBelts = 0;

            for (int i = 1; i <= countOfStudents ; i++)
            {
                if (i%6==0)
                {
                    freeBelts++;
                }
            }

            double sum = priceLightSaber *(countOfStudents +Math.Ceiling(0.1*countOfStudents)) + priceRobes *countOfStudents + priceBelts *(countOfStudents-freeBelts ) ;

            if (sum>amountOfMoney )
            {
                Console.WriteLine($"John will need {sum - amountOfMoney:f2}lv more.");
            }

            else
            {
                Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            }
        }
    }
}
