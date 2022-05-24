using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int redove = int.Parse(Console.ReadLine());
            int koloni = int.Parse(Console.ReadLine());
            double income = koloni * redove;

            if (projectionType == "Premiere")
            {
                income *= 12;
            }


            else if (projectionType == "Normal")
            {
                income *= 7.50;
            }

            else
            {
                income *= 5;
            }
            Console.WriteLine("{0:f2} leva", income);

        }
	}

   }

