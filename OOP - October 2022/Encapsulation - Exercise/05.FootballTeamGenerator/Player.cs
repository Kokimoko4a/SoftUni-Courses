using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        
        private string name;
        private double endrurance;
        private double sprint;
        private double passing;
        private double dribble;
        private double shooting;

        public Player(string name, int endrurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Sprint = sprint;
            Passing = passing;
            Dribble = dribble;
            Shooting = shooting;
            Endurance = endrurance;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public double Endurance
        {
            get { return endrurance; }

            private set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }

                endrurance = value;
            }
        }
        public double Sprint
        {
            get { return sprint; }

            private set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }

                sprint = value;
                ;
            }
        }
        public double Dribble
        {
            get { return dribble; }

            private set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }

                dribble = value;
                ;
            }
        }
        public double Passing
        {
            get { return passing; }

            private set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }

                passing = value;
                ;
            }
        }
        public double Shooting
        {
            get { return shooting; }

            private set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }

                shooting = value;
                ;
            }
        }

        public double OverallSkillLevel { get { return CalculateOverAllSkillLevel(); } }

        private double CalculateOverAllSkillLevel()
        {
            double d = Endurance + Sprint + Dribble + Passing + Shooting;
            double result = d / 5;
            return result;
        }
    }
}
