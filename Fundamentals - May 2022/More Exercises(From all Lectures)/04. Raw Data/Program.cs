using System;
using System.Collections.Generic;

namespace _04._Raw_Data
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < countOfCars; i++)
            {
                string[] arguments = Console.ReadLine().Split();

                Engine currEngine = new Engine(int.Parse(arguments[1]), int.Parse(arguments[2]));
                Cargo currCargo = new Cargo(int.Parse(arguments[3]), arguments[4]);
                Car currCar = new Car(arguments[0], currEngine, currCargo);

                /* currCar.Model = arguments[0];
                 Engine engine = new Engine();
                 engine.Speed = int.Parse(arguments[1]);
                 engine.Power = int.Parse(arguments[2]);
                 Cargo cargo = new Cargo();
                 cargo.Weight = int.Parse(arguments[3]);
                 cargo.Type = arguments[4];

                 currCar.Engine = engine;
                 currCar.Cargo = cargo;*/

                cars.Add(currCar);
            }

            string command = Console.ReadLine();

            foreach (var car in cars)
            {
                if (car.Cargo.Weight < 1000 && command == "fragile")
                {
                    Console.WriteLine(car.Model);
                }

                else if (car.Engine.Power > 250 && command == "flamable")
                {

                    Console.WriteLine(car.Model);
                }
            }
        }
    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }


    }
}
