using _06.FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    public class Rebel : IByuer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public string  Group { get; set; }
        public int Food { get; private set; }

        public int BuyFood()
        {
            Food += 5;
            return 5;
        }
    }
}
