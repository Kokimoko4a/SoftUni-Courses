using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypes = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1 }, { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1 } };
        private List<string> clientWishes = new List<string>();
        private double grams;

        public Dough(List<string> bakingTechniqeAndTypeOfDough, double grams)
        {
            Grams = grams;
            this.BakingTypeAndTypeOfFlourFromTheClient = bakingTechniqeAndTypeOfDough;
        }

        private Dictionary<string, double> DoughsAndModifiersBase { get { return flourTypes; } set { value = flourTypes; } }


        private List<string> BakingTypeAndTypeOfFlourFromTheClient
        {
            get { return clientWishes; }
            set
            {
                foreach (var item in value)
                {
                    if (!flourTypes.ContainsKey(item))
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }
                }

                clientWishes = value;
            }
        }

        public double Grams
        {
            get { return grams; }

           private set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }


        public double CalculateCalsOfDough()
        {
            double calsOfModifaiers = 1;

            foreach (var item in BakingTypeAndTypeOfFlourFromTheClient)
            {
                calsOfModifaiers *= DoughsAndModifiersBase[item];
            }

            return (2 * grams) * calsOfModifaiers;
        }
    }
}
