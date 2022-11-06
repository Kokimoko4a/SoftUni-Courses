using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wingsize) : base(name, weight)
        {
            WingSize = wingsize;
        }

        public double WingSize { get; set; }
    }
}
