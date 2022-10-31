using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model,Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model,Engine engine, int weight,string color)
        {
            Model=model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public Car(string model,  Engine engine, string color)
        {
            Color = color;
            Engine = engine;
            Model = model;
        }

        public Car(string model, Engine engine, int weight)
        {
            Model = model;
            Engine=engine;
            Weight = weight;
        }

        public string Color { get; set; }
        public int Weight { get; set; }
        public Engine Engine { get; set; }
        public string Model { get; set; }
    }
}
