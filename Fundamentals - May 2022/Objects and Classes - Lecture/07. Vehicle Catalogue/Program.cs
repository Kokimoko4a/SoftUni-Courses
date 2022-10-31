using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            VehicleCatalog catalog = new VehicleCatalog();
            catalog.Cars = new List<Car>();
            catalog.Trucks = new List<Truck>();          

            while (command != "end")
            {
                string[] arguments = command.Split('/');

                string currType = arguments[0];
                string currBrand = arguments[1];
                string currModel = arguments[2];
                int currHPOrWeight = int.Parse(arguments[3]);

                if (currType == "Car")
                {
                    Car currCar = new Car();
                    currCar.Type = currType;
                    currCar.Brand = currBrand;
                    currCar.Model = currModel;
                    currCar.HorsePower = currHPOrWeight;

                    catalog.Cars.Add(currCar);
                }

                else if (currType == "Truck")
                {
                    Truck currtruck = new Truck();
                    currtruck.Type = currType;
                    currtruck.Brand = currBrand;
                    currtruck.Model = currModel;
                    currtruck.Weight = currHPOrWeight;

                    catalog.Trucks.Add(currtruck);
                }

                command = Console.ReadLine();
            }

            catalog.Cars = catalog.Cars.OrderBy(brand => brand.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(brand => brand.Brand).ToList();

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
            }

            foreach (var car in catalog.Cars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }

            foreach (var truck in catalog.Trucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    class Car
    {
        //Brand, Model, and Horse Power.

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }


    class Truck
    {
        //Brand, Model, and Weight.

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }

    class VehicleCatalog
    {
        //Brand, Model, and Weight.
        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }
    }
}
