using System;
using System.Collections.Generic;

namespace _03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carsInfos = new Dictionary<string, Car>();
            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] arguments = Console.ReadLine().Split('|');
                string name = arguments[0];
                int currMileage = int.Parse(arguments[1]);
                int currFuelAmount = int.Parse(arguments[2]);

                Car currcar = new Car(currMileage, currFuelAmount);
                carsInfos.Add(name, currcar);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] arguments = command.Split(" : ");
                string action = arguments[0];

                if (action == "Drive")
                {
                    string name = arguments[1];
                    int distance = int.Parse(arguments[2]);
                    int fuelNeeded = int.Parse(arguments[3]);

                    if (carsInfos[name].FuelAmount >= fuelNeeded)
                    {
                        carsInfos[name].Mileage += distance;
                        carsInfos[name].FuelAmount -= fuelNeeded;
                        Console.WriteLine($"{name} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                    }

                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (carsInfos[name].Mileage >= 100000)
                    {
                        carsInfos.Remove(name);
                        Console.WriteLine($"Time to sell the {name}!");
                    }
                }

                else if (action == "Refuel")
                {
                    //"{car} refueled with {fuel} liters"

                    string name = arguments[1];
                    int refueledAmount = int.Parse(arguments[2]);
                    int neshto = 75 - carsInfos[name].FuelAmount;

                    if (carsInfos[name].FuelAmount + refueledAmount > 75)
                    {
                        carsInfos[name].FuelAmount += neshto;
                        Console.WriteLine($"{name} refueled with {neshto} liters");
                    }

                    else
                    {
                        carsInfos[name].FuelAmount += refueledAmount;
                        Console.WriteLine($"{name} refueled with {refueledAmount } liters");
                    }
                }

                else if (action == "Revert")
                {
                    string name = arguments[1];
                    int miliagesToRevert = int.Parse(arguments[2]);

                    carsInfos[name].Mileage -= miliagesToRevert;

                    if (carsInfos[name].Mileage < 10000)
                    {
                        carsInfos[name].Mileage = 10000;
                    }

                    else
                    {
                        Console.WriteLine($"{name} mileage decreased by {miliagesToRevert} kilometers");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in carsInfos)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.FuelAmount} lt.");
            }
        }
    }

    class Car
    {
        public Car(int mileage, int fuelAmount)
        {
            Mileage = mileage;
            FuelAmount = fuelAmount;
        }
        public int Mileage { get; set; }
        public int FuelAmount { get; set; }
    }
}
