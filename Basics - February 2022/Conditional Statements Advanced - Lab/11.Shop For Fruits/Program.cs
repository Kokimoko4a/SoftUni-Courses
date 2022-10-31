using System;

namespace _11.Shop_For_Fruits
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double totalsum = 0.0;
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (product)
                    {

                        case "banana":
                            totalsum = count * 2.50;
                            break;

                        case "apple":
                            totalsum = count * 1.20;
                            break;

                        case "orange":
                            totalsum = count * 0.85;
                            break;

                        case "grapefruit":
                            totalsum = 1.45 * count;
                            break;

                        case "kiwi":
                            totalsum = 2.70* count;
                            break;

                        case "pineapple":
                            totalsum = count * 5.5;
                            break;

                        case "grapes":
                            totalsum = count * 3.85;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;

                case "Saturday":
                case "Sunday":

                    switch (product)
                    {

                        case "banana":
                            totalsum = count * 2.7;
                            break;

                        case "apple":
                            totalsum = count * 1.25;
                            break;

                        case "orange":
                            totalsum = count * 0.9;
                            break;

                        case "grapefruit":
                            totalsum = 1.6 * count;
                            break;

                        case "kiwi":
                            totalsum = 3.00 * count;
                            break;

                        case "pineapple":
                            totalsum = count * 5.6;
                            break;

                        case "grapes":
                            totalsum = count * 4.2;
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                
                    break;


                default:
                    Console.WriteLine("error");
                    break;

            }
            if (totalsum > 0)
            {
                Console.WriteLine($"{totalsum:f2}");
            }
        }
    }
}
