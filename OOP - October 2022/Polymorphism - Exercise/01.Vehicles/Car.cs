using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double km)
        {
            if (FuelQuantity - ((FuelConsumption + 0.9) * km) >= 0)
            {
                FuelQuantity -= ((FuelConsumption + 0.9) * km);
                return $"Car travelled {km} km";
            }

            return "Car needs refueling";
        }

        public override void Refuel(double fuel)
        {
           FuelQuantity+=fuel;
        }
    }
}
