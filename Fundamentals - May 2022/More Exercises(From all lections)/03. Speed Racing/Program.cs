using System;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int countOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();


            for (int i = 0; i < countOfCars; i++)
            {

                string[] arguments = Console.ReadLine().Split();

                Car currCar = new Car(arguments[0], double.Parse(arguments[1]), double.Parse(arguments[2]), 0);

                cars.Add(currCar);

            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] arguments = command.Split();

                string action = arguments[0];
                string currModel = arguments[1];
                double kmToTravel = double.Parse(arguments[2]);

                if (action == "Drive")
                {

                    var currCar = cars.Find(x => x.Model == currModel);

                    double needeFuel = kmToTravel * currCar.FuelAmountFor1Km;

                    if (currCar.FuelAmount - needeFuel >= 0)
                    {
                        currCar.FuelAmount -= needeFuel;

                        currCar.TravelledKm += kmToTravel;
                    }

                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

    class Car
    {

        public Car(string model, double fuelAmount, double fuelAmountFor1Km, double travelledKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelAmountFor1Km = fuelAmountFor1Km;
            TravelledKm = travelledKm;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelAmountFor1Km { get; set; }

        public double TravelledKm { get; set; }


        public override string ToString() => $"{Model} {FuelAmount:f2} {TravelledKm} ";


    }
}
