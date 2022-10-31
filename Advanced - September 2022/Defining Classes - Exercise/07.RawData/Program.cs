using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {

            int countOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
           

            for (int i = 0; i < countOfCars; i++)
            {
                Tire[] tires = new Tire[4];
                string[] arguments = Console.ReadLine().Split();

                Engine currEngine = new Engine(int.Parse(arguments[1]), int.Parse(arguments[2]));
                Cargo currCargo = new Cargo(int.Parse(arguments[3]), arguments[4]);
                Tire firstTire = new Tire(double.Parse(arguments[5]), int.Parse(arguments[6]));
              
                Tire secondTire = new Tire(double.Parse(arguments[7]), int.Parse(arguments[8]));
                Tire thirdTire = new Tire(double.Parse(arguments[9]), int.Parse(arguments[10]));
                Tire fourthTire = new Tire(double.Parse(arguments[11]), int.Parse(arguments[12]));

                tires[0] = firstTire;
                tires[1] = secondTire;
                tires[2] = thirdTire;
                tires[3] = fourthTire;

                Car currCar = new Car(arguments[0], currEngine, currCargo,tires);

                cars.Add(currCar);
            }

            string command = Console.ReadLine();

            foreach (var car in cars)
            {
                if (car.Tires.Any(x=>x.Pressure<1) && command == "fragile")
                {
                    Console.WriteLine(car.Model);
                }

                else if (car.Engine.Power > 250 && command == "flammable")
                {

                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
