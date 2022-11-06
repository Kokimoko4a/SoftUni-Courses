using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
