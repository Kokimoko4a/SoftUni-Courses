using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());
            List<Car> carsInfo = new List<Car>();

            for (int i = 0; i < countOfCars; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(arguments[0], double.Parse(arguments[1]), double.Parse(arguments[2]));
                carsInfo.Add(car);
            }

            string command = Console.ReadLine();

            while (command!= "End")
            {
                string[] tokens = command.Split();
                Car currCar = carsInfo.Find(x => x.Model == tokens[1]);
                double amountOfKilometres = double.Parse(tokens[2]);

                currCar.Drive(amountOfKilometres);

                command = Console.ReadLine();
            }

            foreach (var car in carsInfo)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
