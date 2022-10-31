using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string command = Console.ReadLine();
            int index = 0;

            while (command != "No more tires")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List<Tire> currFourTires = new List<Tire>();


                for (int i = 0; i < tokens.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        int year = int.Parse(tokens[i]);
                        double pressure = double.Parse(tokens[i + 1]);
                        Tire currTire = new Tire(year, pressure);
                        currFourTires.Add(currTire);
                    }

                    else
                    {
                        continue;
                    }
                }

                tires.Add(new Tire[4]);
                tires[index] = currFourTires.ToArray();
                index++;
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(tokens[0]);
                double cubicPower = double.Parse(tokens[1]);

                Engine currEngine = new Engine(horsePower, cubicPower);

                engines.Add(currEngine);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Show special")
            {
                string[] tokens = command.Split();
                int indexOfTire = int.Parse(tokens[6]);
                int indexOfEngine = int.Parse(tokens[6]);
                Engine engine = engines[indexOfEngine];


                Car currCar = new Car();

                currCar.Make = tokens[0];
                currCar.Model = tokens[1];
                currCar.Year = int.Parse(tokens[2]);
                currCar.FuelQuantity = double.Parse(tokens[3]);
                currCar.FuelConsumption = double.Parse(tokens[4]);
                currCar.Engine = engine;
                currCar.Tires = tires[indexOfTire];

                cars.Add(currCar);
                command = Console.ReadLine();
            }

            foreach (var item in cars)
            {
                double sum = 0;

                foreach (var tire in item.Tires)
                {
                    sum += tire.Pressure;
                }

                if (item.Year >= 2017 && item.Engine.HorsePower >= 330 && sum >= 9 && sum <= 10)
                {
                    item.Drive(20);
                    Console.WriteLine(item.WhoAmI());
                }
            }
        }
    }
}
