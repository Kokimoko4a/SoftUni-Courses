using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int endurance;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel
        {
            get
            {

                return endurance;
            }
            private set
            {
                if (value > 20)
                {
                    throw new ArgumentException("Endurance level cannot exceed 20 power points.");
                }

                endurance = value;
            }
        }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
        }
    }
}
