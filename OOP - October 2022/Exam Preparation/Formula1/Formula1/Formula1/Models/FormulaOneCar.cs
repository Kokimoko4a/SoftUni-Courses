using Formula1.Core;
using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException($"Invalid car model: {value}.");
                }

                model = value;
            }
        }

        public int Horsepower
        {
            get { return horsepower; }
            private set
            {
                /*o	If the horsepower is less than 900, or more than 1050,*/
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: {value}.");
                }

                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set
            {
                /*o	If the engine displacement  is less than 1.6, or more than 2.00*/

                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException($"Invalid car engine displacement: {value}.");
                }

                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }
    }
}
