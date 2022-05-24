using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* Friday Saturday    Sunday
Students      8.45      9.80      10.46
Business       10.90   15.60       16
Regular         15      20        22.50*/

            int people = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string day = Console .ReadLine();
            double price = 0;

            if (typeGroup =="Students")
            {
                if (day=="Friday")
                {
                    price = 8.45; 
                }

                else if (day == "Saturday")
                {
                    price = 9.80;
                }

                else if (day=="Sunday")
                {
                    price = 10.46;
                }

                if (people >= 30)
                {
                    price -= price * 0.15;
                }
            }

            else if (typeGroup == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                }

                else if (day == "Saturday")
                {
                    price = 15.60;
                }

                else if (day == "Sunday")
                {
                    price = 16;
                }

                if (people >= 100)
                {
                    people -= 10;
                    
                }
            }

            if (typeGroup == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                }

                else if (day == "Saturday")
                {
                    price = 20;
                }

                else if (day == "Sunday")
                {
                    price = 22.50;
                }

                if (people >= 10 && people <=20)
                {
                    price -= price * 0.05;
                }
            }

            double totalPrice = people * price;
            Console.WriteLine($"Total price: {totalPrice:f2}");



        }
    }
}
