using System;

namespace _02.VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Vehicle car = new Car(0,0,0);
            Vehicle truck = new Truck(0,0,0);
            Bus bus = new Bus(0,0,0);

           

            for (int i = 0; i < 3; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arguments[0] == "Car")
                {
                    car = new Car(double.Parse(arguments[1]), double.Parse(arguments[2]), double.Parse(arguments[3]));
                }

                else if (arguments[0] == "Truck")
                {
                    truck = new Truck(double.Parse(arguments[1]), double.Parse(arguments[2]), double.Parse(arguments[3]));
                }

                else if (arguments[0] == "Bus")
                {
                    bus = new Bus(double.Parse(arguments[1]), double.Parse(arguments[2]), double.Parse(arguments[3]));
                }
            }


            int countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {            
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arguments[0] == "Drive" || arguments[0] == "DriveEmpty")
                {
                    if (arguments[1] == "Car")
                    {

                        Console.WriteLine(car.Drive(double.Parse(arguments[2])));
                    }

                    else if (arguments[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(arguments[2])));
                    }

                    else if (arguments[1] == "Bus")
                    {
                        if (arguments[0] == "Drive")
                        {
                            bus.IsEmpty = false;                         
                        }

                        else if (arguments[0] == "DriveEmpty")
                        {
                            bus.IsEmpty = true;              
                        }

                        Console.WriteLine(bus.Drive(double.Parse(arguments[2])));
                    }
                }

                else if (arguments[0] == "Refuel")
                {
                    if (arguments[1] == "Car")
                    {
                        car.Refuel(double.Parse(arguments[2]));
                    }

                    else if (arguments[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(arguments[2]));
                    }

                    else if (arguments[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(arguments[2]));
                    }
                }
            }


            /*	"Car: {liters}"
            	"Truck: {liters}"*/

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
            
        }
    }
}
