using System;

namespace _05._Hair_Salon
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            string typeOfDoing;
            int  sum = 0;

            while ((typeOfDoing  = Console.ReadLine ())!="closed")
            {
               
               

                if (typeOfDoing == "haircut")
                {
                    string typehair = Console.ReadLine();
                    if (typehair =="mens")
                    {
                        sum += 15;
                    }

                    else if (typehair =="ladies")
                    {
                        sum += 20;
                    }

                    else if (typehair == "kids")
                    {
                        sum += 10;
                    }
                }

                else if (typeOfDoing =="color")
                {
                    string typehair = Console.ReadLine();

                    if (typehair =="touch up")
                    {
                        sum += 20;
                    }

                    else if (typehair =="full color")
                    {
                        sum += 30;
                    }
                }

                if (sum>=target )
                {
                    
                    break;
                }
            }

            if (sum>=target )
            {
                Console.WriteLine("You have reached your target for the day!");
            }

            else
            {
                Console.WriteLine($"Target not reached! You need {target -sum}lv. more.");
            }

            Console.WriteLine($"Earned money: {sum}lv.");
        }
    }
}
