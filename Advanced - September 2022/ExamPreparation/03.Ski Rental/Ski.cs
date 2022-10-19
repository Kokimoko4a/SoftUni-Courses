using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SkiRental
{
    public class Ski
    {
        public Ski(string manufacturer, string model,int year)
        {
            Model = model;
            Manufacturer = manufacturer;
            Year = year;
        }

        public int Year { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer} - {Model} - {Year}";
        }
    }

}
