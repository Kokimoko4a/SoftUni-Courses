using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dictionary<string, double> toppings = new Dictionary<string, double>();
        private int Count = 0;

        public Pizza(string name)
        {
            Name = name;
        }

        public Pizza()
        {
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 15 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }
        public double Calories { get { return CalcCals(); } }

        private double CalcCals()
        {
            double calsOfDough = Dough.CalculateCalsOfDough();
            double total = 0;

            foreach (var item in toppings)
            {
                total += item.Value;
            }

            return calsOfDough + total;
        }

        public void AddTopping(Topping topping)
        {
            Count++;

            if (Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            else if (!toppings.ContainsKey(topping.WishFromTheClient))
            {
                toppings.Add(topping.WishFromTheClient, topping.TotalCals);
            }

            else
            {
                toppings[topping.WishFromTheClient] += topping.TotalCals;
            }
        }
    }
}
