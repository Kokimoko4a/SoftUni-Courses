using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public int MaxAlcoholLevel { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            Ingredient indredient1 = Ingredients.FirstOrDefault(x => x.Name == ingredient.Name);

            if (indredient1 == null && Capacity > Ingredients.Count && CurrentAlcoholLevel + ingredient.Alcohol <=MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
                CurrentAlcoholLevel+=ingredient.Alcohol;
                
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.FirstOrDefault(x => x.Name == name) != null)
            {
                CurrentAlcoholLevel -= Ingredients.Find(x => x.Name == name).Alcohol;
                Ingredients.Remove(Ingredients.Find(x => x.Name == name));
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).First();
        }


        public string Report()
        { 
            return $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}{Environment.NewLine}"+
                string.Join(Environment.NewLine,Ingredients);
        }
    }
}
