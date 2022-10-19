using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {
        public Car(string manufacturer,string model,int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public int Year { get; set; }
        public string Model { get; set; }
        public string	Manufacturer { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} ({Year})";
        }
    }
}
