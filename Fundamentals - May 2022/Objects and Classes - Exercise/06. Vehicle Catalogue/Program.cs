using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Vehicle> allVehicles = new List<Vehicle>();
            double countOfCars = 0;
            double countOfTrucks = 0;
            double sumHpCars = 0;
            double sumTrucksHP = 0;
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] arguments = command.Split();

                Vehicle vehicle = new Vehicle(arguments[0], arguments[1], arguments[2], double.Parse(arguments[3]));

                if (vehicle.Type == "car")
                {

                    countOfCars++;
                    sumHpCars += vehicle.HP;
                }

                else
                {

                    countOfTrucks++;
                    sumTrucksHP += vehicle.HP;
                }

                allVehicles.Add(vehicle);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Close the Catalogue")
            {

                foreach (var vehicle in allVehicles)
                {
                    if (command == vehicle.Model)
                    {

                        if (vehicle.Type == "car")
                        {
                            Console.WriteLine("Type: Car");
                        }

                        else
                        {
                            Console.WriteLine("Type: Truck");
                        }


                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.HP}");
                    }
                }

                command = Console.ReadLine();

            }

            decimal averageCarsHP = 0.00M;

            if (countOfCars > 0)
            {
                averageCarsHP = (decimal)(sumHpCars / countOfCars);
            }


            decimal averageTrucksHP = 0.00M;

            if (countOfTrucks > 0)

            {
                averageTrucksHP = (decimal)(sumTrucksHP / countOfTrucks);
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCarsHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHP:f2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, double hP)
        {
            Type = type;
            Model = model;
            Color = color;
            HP = hP;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HP { get; set; }
    }
}
