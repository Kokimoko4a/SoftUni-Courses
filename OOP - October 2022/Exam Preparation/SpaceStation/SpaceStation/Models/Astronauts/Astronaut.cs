using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {

        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            Name= name;
            Oxygen= oxygen;
            Bag = new Backpack();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public bool CanBreath { get { return Oxygen != 0; } }

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            if (Oxygen - 10 < 0)
            {
                Oxygen = 0;
            }

            else
            {
                Oxygen -= 10;
            }

           
        }
    }
}
