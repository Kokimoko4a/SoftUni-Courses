using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }

        public override string Drive(double km)
        {
            if (IsEmpty)
            {
                if (FuelQuantity - (FuelConsumption * km) >= 0)
                {
                    FuelQuantity -= FuelConsumption * km;
                    return $"Bus travelled {km} km";
                }

                return "Bus needs refueling";
            }

            else
            {
                if (FuelQuantity - ((FuelConsumption + 1.4) * km) >= 0)
                {
                    FuelQuantity -= ((FuelConsumption + 1.4) * km);
                    return $"Bus travelled {km} km";
                }

                return "Bus needs refueling";
            }
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
