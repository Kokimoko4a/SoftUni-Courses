using System;

namespace _12._Търговски_комисионни
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTown = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            if (nameOfTown == "Sofia")
            {

                if (sales >= 0 && sales <= 500)
                {
                    double komis = 0.05 * sales;

                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double komis = 0.07 * sales;
                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double komis = 0.08 * sales;
                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 10000)
                {
                    double komis = 0.12 * sales;
                    Console.WriteLine($"{komis:f2}");


                }
                else if (sales < 0) {
                    Console.WriteLine("error");
                }
            }


            else if (nameOfTown == "Varna")
            {

                if (sales >= 0 && sales <= 500)
                {
                    double komis = 0.045 * sales;

                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double komis = 0.075 * sales;
                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double komis = 0.1 * sales;
                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 10000)
                {
                    double komis = 0.13 * sales;
                    Console.WriteLine($"{komis:f2}");
                }

                else if (sales < 0)
                {
                    Console.WriteLine("error");
                }
            }


            else if (nameOfTown == "Plovdiv")
            {

                if (sales >= 0 && sales <= 500)
                {
                    double komis = 0.055 * sales;

                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    double komis = 0.08 * sales;
                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    double komis = 0.12 * sales;
                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales > 10000)
                {
                    double komis = 0.145 * sales;
                    Console.WriteLine($"{komis:f2}");
                }
                else if (sales < 0)
                {
                    Console.WriteLine("error");
                }
            }
            
            else {
                Console.WriteLine("error");
            }
            
        }
    }
}
