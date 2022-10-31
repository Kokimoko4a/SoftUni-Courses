using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> baseToppingsAndCals = new Dictionary<string, double> { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

        private string toppingWishOriginal;
        private double grams;
        private string originalTopping;
        public Topping(string tooping, double grams)
        {
            this.originalTopping = tooping;
            tooping = tooping.ToLower();
            WishFromTheClient = tooping;
            Grams = grams;

        }

        public string WishFromTheClient
        {
            get { return toppingWishOriginal; }
            private set
            {
                if (!baseToppingsAndCals.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {originalTopping} on top of your pizza.");
                }


                toppingWishOriginal = value;
            }
        }


        public double TotalCals { get { return CalcCals(); } }

        public double Grams
        {
            get { return grams; }
            private set
            {

                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{originalTopping} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        private double CalcCals()
        {
            double calsOfModifaiers = 1;

            calsOfModifaiers *= baseToppingsAndCals[WishFromTheClient];

            return (2 * Grams) * calsOfModifaiers;

        }
    }
}
