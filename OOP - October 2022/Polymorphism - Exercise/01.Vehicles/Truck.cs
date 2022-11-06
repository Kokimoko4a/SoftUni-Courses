using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double km)
        {
            if (FuelQuantity - ((FuelConsumption +1.6) * km ) >= 0)
            {
                FuelQuantity -= ((FuelConsumption + 1.6) * km);
                return $"Truck travelled {km} km";
            }

            return "Truck needs refueling";
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel - (0.05 * fuel);
        }
    }
}
