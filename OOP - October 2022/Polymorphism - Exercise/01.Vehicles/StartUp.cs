using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int countOfLines = int.Parse(Console.ReadLine());

            Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));
            Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

            for (int i = 0; i < countOfLines; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arguments[0] == "Drive")
                {
                    if (arguments[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(arguments[2])));
                    }

                    else
                    {
                        Console.WriteLine(truck.Drive(double.Parse(arguments[2])));
                    }
                }

                else if (arguments[0] == "Refuel")
                {
                    if (arguments[1] == "Car")
                    {
                       car.Refuel(double.Parse(arguments[2]));
                    }

                    else
                    {
                        truck.Refuel(double.Parse(arguments[2]));
                    }
                }
            }


            /*	"Car: {liters}"
            	"Truck: {liters}"*/

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

        }
    }
}
