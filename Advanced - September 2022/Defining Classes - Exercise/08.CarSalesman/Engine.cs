using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model,int power)
        {
            Model = model;
            Power = power;
           
        }

        public string Efficiency { get; set; }
        public int Displacement { get; set; }
        public int Power { get; set; }
        public string Model { get; set; }
    }
}
