using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            if (month == "May" || month  == "October")
            {
                studioPrice = 50 * nights;
                apartmentPrice = 65 * nights;

            }

            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20 * nights;
                apartmentPrice = 68.70 * nights;
            }

            else
            {
                studioPrice = 76 * nights;
                apartmentPrice = 77 * nights;
            }

            if (nights > 14)
            {
                apartmentPrice = apartmentPrice - apartmentPrice * 10 / 100;
                if (month == "October" || month == "May")
                {
                    studioPrice = studioPrice - studioPrice * 30 / 100;
                }

                else if (month == "June" || month == "September")
                {
                    studioPrice = studioPrice - studioPrice * 20 / 100;
                }
            }

            else if (nights > 7 && (month == "October" || month == "May"))
            {
                studioPrice = studioPrice -studioPrice *5/100;              
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
