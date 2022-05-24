using System;

namespace Задача_3._Художествена_гимнастика
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string tool = Console.ReadLine();
            double difficulty = 0;
            double performace = 0;

            switch (country)
            {
                case "Russia":
                    
                    switch (tool)
                    {
                        case "ribbon":
                            difficulty = 9.1;
                            performace = 9.4;
                            break;
                        case "hoop":
                            difficulty =9.3;
                            performace =9.8;
                            break;
                        case "rope":
                            difficulty = 9.6;
                            performace = 9.0;
                            break;
                            

                    }
                    break;


                case "Bulgaria":

                    switch (tool)
                    {
                        case "ribbon":
                        difficulty = 9.6;
                            performace = 9.4;
                            break;
                        case "hoop":
                        difficulty = 9.55;
                            performace = 9.75;
                            break;
                        case "rope":
                            difficulty = 9.5;
                            performace = 9.4;
                            break;



                    }
                    break;


                case "Italy":

                    switch (tool)
                    {
                        case "ribbon":
                        difficulty = 9.2;
                            performace = 9.5;
                            break;
                        case "hoop":
                        difficulty = 9.45;
                            performace = 9.35;
                            break;
                        case "rope":
                            difficulty = 9.7;
                            performace = 9.15;
                            break;



                    }
                    break;
            }

            double total = difficulty + performace;
            
                Console.WriteLine($"The team of {country} get {total:f3} on {tool}.");
            double percents = (20-total) / 20 * 100;
            Console.WriteLine($"{percents:f2}%");
            



        }
    }
}
