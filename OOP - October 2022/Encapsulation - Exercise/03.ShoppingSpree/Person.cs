using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

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

        public int Money
        {
            get { return money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts { get; set; }
    }
}
