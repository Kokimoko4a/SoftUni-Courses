using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
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
            if (CanAddFuel(fuel))
            {
                FuelQuantity += fuel;
            }
           
        }
    }
}
