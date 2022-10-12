using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public double TravelledDistance { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double FuelAmount { get; set; }
        public string Model { get; set; }

        public void Drive(double amountOfKilometres)
        {
            double currFuel = FuelAmount;
            currFuel -= amountOfKilometres * FuelConsumptionPerKilometer;

            if (currFuel >= 0)
            {
                FuelAmount = currFuel;
                TravelledDistance += amountOfKilometres;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }
    }
}
