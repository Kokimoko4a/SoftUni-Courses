using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Xml.Linq;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name,string type,double rate,int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
            Hired = false;
        }

        public bool Hired { get; set; }
        public int Days { get; set; }
        public double Rate { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"-Renovator: {Name}{Environment.NewLine}" +
                $"--Specialty: {Type}{Environment.NewLine}" +
                $"--Rate per day: {Rate} BGN";

        }
    }
}
