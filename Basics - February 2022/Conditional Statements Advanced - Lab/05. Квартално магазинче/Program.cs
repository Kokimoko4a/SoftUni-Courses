using System;

namespace _05._Квартално_магазинче
{
    class Program
    {
        static void Main(string[] args)
        {

            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double totalsum = 0.0;
            switch (town)
            {
                case "Varna":
                    switch (product) {

                        case "coffee":
                            totalsum = count * 0.45;
                            break;

                        case "water":
                            totalsum = count * 0.7;
                            break;

                        case "beer":
                            totalsum = count * 1.10;
                            break;

                        case "sweets":
                            totalsum = 1.35 * count;
                            break;

                        case "peanuts":
                            totalsum = count * 1.55;
                            break;
                    }
                    break;

                case "Plovdiv":
                    switch (product) {

                        case "coffee":
                            totalsum = count * 0.4;
                            break;

                        case "water":
                            totalsum = count * 0.7;
                            break;

                        case "beer":
                            totalsum = count * 1.15;
                            break;

                        case "sweets":
                            totalsum = 1.30 * count;
                            break;

                        case "peanuts":
                            totalsum = count * 1.5;
                            break;
                    }
                    break;

                case "Sofia":
                    switch (product) {

                        case "coffee":
                            totalsum = count * 0.5;
                            break;

                        case "water":
                            totalsum = count * 0.8;
                            break;

                        case "beer":
                            totalsum = count * 1.20;
                            break;

                        case "sweets":
                            totalsum = 1.45 * count;
                            break;

                        case "peanuts":
                            totalsum = count * 1.60;
                            break;
                    }
                    break;


            }
            Console.WriteLine(totalsum);
        }
    }
}
