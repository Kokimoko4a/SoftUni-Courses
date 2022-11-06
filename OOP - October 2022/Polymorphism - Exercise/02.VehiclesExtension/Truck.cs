using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double km)
        {
            if (FuelQuantity - ((FuelConsumption + 1.6) * km) >= 0)
            {
                FuelQuantity -= ((FuelConsumption + 1.6) * km);
                return $"Truck travelled {km} km";
            }

            return "Truck needs refueling";
        }

        public override void Refuel(double fuel)
        {
            if (CanAddFuel(fuel))
            {
                FuelQuantity += fuel - (0.05 * fuel);
            }

           
        }
    }
}
