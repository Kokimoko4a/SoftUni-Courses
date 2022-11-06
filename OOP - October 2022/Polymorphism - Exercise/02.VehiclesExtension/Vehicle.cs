using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }

            set
            {
                if (value > TankCapacity)
                {
                    value = 0;

                }

                fuelQuantity = value;
            }
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public abstract string Drive(double km);

        public abstract void Refuel(double fuel);

        protected bool CanAddFuel(double fuelToAdd)
        {
            if (fuelToAdd<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return false;
              
            }

            if (FuelQuantity+ fuelToAdd>TankCapacity )
            {
                Console.WriteLine($"Cannot fit {fuelToAdd} fuel in the tank");
                return false;
            }

            return true;
        }

    }
}
