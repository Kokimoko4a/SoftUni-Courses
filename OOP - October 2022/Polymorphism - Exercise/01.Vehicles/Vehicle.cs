using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity,double fuelConsumption)
        {
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }

        public double  FuelQuantity { get; set; }
        public double  FuelConsumption { get; set; }


        public abstract string Drive(double km);

        public abstract void Refuel(double fuel);
    }
}
