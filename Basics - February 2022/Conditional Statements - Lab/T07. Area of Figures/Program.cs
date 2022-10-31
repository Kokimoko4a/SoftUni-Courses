using System;

namespace T07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureName = Console.ReadLine();

            if (figureName == "square")
            {

                double figureSide = double.Parse(Console.ReadLine());
                double resultOfSides = figureSide * figureSide;
                Console.WriteLine($"{resultOfSides:f3}");
            }

            else if (figureName == "rectangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                double finalResult = side1 * side2;
                Console.WriteLine($"{finalResult:f3}");
            }
            else if (figureName == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double finalRadius = radius * radius * Math.PI;
                Console.WriteLine($"{finalRadius:f3}");
            }
            else if (figureName == "triangle") {

                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                double finalResult = side1 * side2 / 2;
                Console.WriteLine($"{finalResult:f3}");
            }


        }
    }
}
