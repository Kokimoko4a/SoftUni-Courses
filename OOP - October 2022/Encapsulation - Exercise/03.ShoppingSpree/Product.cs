using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        private string name;
        private int cost;

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Cost
        {
            get { return cost; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }
    }
}
