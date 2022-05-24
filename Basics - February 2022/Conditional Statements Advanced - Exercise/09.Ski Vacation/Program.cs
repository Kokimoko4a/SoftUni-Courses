using System;

namespace _09.Ski_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string review = Console.ReadLine();
            int nights = days - 1;
            double roomForOne = 18.00;
            double apartment = 25.00;
            double presidentApartment = 35.00;
            double price;

            if (typeOfRoom == "room for one person")
            {
                
                     price = nights * roomForOne;

            }

            else if (typeOfRoom == "apartment")
            {
                price = nights * apartment;
                if (nights < 10)
                {

                    price = price - price * 0.3;
                }

                else if (nights > 10 && nights < 15)
                {
                    price = price - price * 0.35;
                }

                else if (nights > 15)
                {
                    price = price - price * 0.5;
                }
            }

            else
            {
                price = nights * presidentApartment ;

                if (nights < 10)
                {

                    price = price - price * 0.1;
                }

                else if (nights > 10 && nights < 15)
                {
                    price = price - price * 0.15;
                }

                else if (nights > 15)
                {
                    price = price - price * 0.2;
                }
            }


             if (review == "positive")
                    {
                        price = price + price * 0.25;
                    }

                    else if (review == "negative")
                    {
                        price = price - price * 0.1;
                    }
            Console.WriteLine($"{price:f2}");


        }
    }
}
