using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfEngines = int.Parse(Console.ReadLine());
            List<Engine> enginesInfo = new List<Engine>();
            List<Car> carsInfo = new List<Car>();

            for (int i = 0; i < countOfEngines; i++)
            {
                //"{model} {power} {displacement} {efficiency}"
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(arguments[0], int.Parse(arguments[1]));

                if (arguments.Length == 3)
                {
                    if (char.IsLetter(arguments[2][0]))
                    {
                        engine.Efficiency = arguments[2];
                    }

                    else
                    {
                        engine.Displacement = int.Parse(arguments[2]);
                    }
                }

                if (arguments.Length == 4)
                {
                    engine.Displacement = int.Parse(arguments[2]);
                    engine.Efficiency = arguments[3];
                }

                enginesInfo.Add(engine);
            }

            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string modelOfEngine = arguments[1];
                Engine engine = enginesInfo.Find(x => x.Model == modelOfEngine);

          

                if (arguments.Length == 2)
                {
                    Car car = new Car(arguments[0], engine);
                    carsInfo.Add(car);
                }

                else if (arguments.Length == 3)
                {
                    if (char.IsLetter(arguments[2][0]))
                    {
                        Car car = new Car(arguments[0], engine, arguments[2]);
                        carsInfo.Add(car);
                    }

                    else
                    {
                        Car car = new Car(arguments[0], engine, int.Parse(arguments[2]));
                        carsInfo.Add(car);
                    }
         
                }


                else
                {
                    Car car = new Car(arguments[0], engine, int.Parse(arguments[2]), arguments[3]);
                    carsInfo.Add(car); 
                }

                
            }

            foreach (var car in carsInfo)
            {
                /* "{CarModel}:
                 { EngineModel}:
                  Power: { EnginePower}
                  Displacement: { EngineDisplacement}
                  Efficiency: { EngineEfficiency}
                 Weight: { CarWeight}
                 Color: { CarColor}
                 "*/

                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"    {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }

                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                if (car.Engine.Efficiency == null)
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }

                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if (car.Weight == 0)
                {
                    Console.WriteLine($"    Weight: n/a");
                }

                else
                {
                    Console.WriteLine($"    Weight: {car.Weight}");
                }

                if (car.Color == null)
                {
                    Console.WriteLine("     Color: n/a");
                }

                else
                {
                    Console.WriteLine($"    Color: {car.Color}");
                }
              
            }


        }
    }
}
