using _06.FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    public class Citizen : IByuer
    {
        public Citizen(string name, int age, string id, string birtdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birtdate = birtdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; set; }

        public string Birtdate { get; set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
