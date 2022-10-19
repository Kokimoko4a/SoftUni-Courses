using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredientValues = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshnessLevelValues = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<double, Meal> meals = new Dictionary<double, Meal>();
            meals.Add(150, new Meal("Dipping sauce", 0)); ;
            meals.Add(250, new Meal("Green salad", 0));
            meals.Add(300, new Meal("Chocolate cake", 0));
            meals.Add(400, new Meal("Lobster", 0));

            while (ingredientValues.Count > 0 && freshnessLevelValues.Count > 0)
            {
                int currIngredient = ingredientValues.Dequeue();

                if (currIngredient == 0)
                {
                    continue;
                }

                int currFreshness = freshnessLevelValues.Pop();
                int currMix = currFreshness * currIngredient;

                if (meals.ContainsKey(currMix))
                {
                    meals[currMix].Count++;
                }

                else
                {
                    currIngredient += 5;
                    ingredientValues.Enqueue(currIngredient);
                }
            }

            bool isCompleted = meals.All(x => x.Value.Count > 0);

            if (isCompleted)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }


            if (ingredientValues.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientValues.Sum()}");
            }

            foreach (var item in meals.OrderBy(x => x.Value.Name).Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($" # {item.Value.Name} --> {item.Value.Count}");
            }

        }
    }

    class Meal
    {
        public Meal(string name, int count)
        {
            Count = count;
            Name = name;
        }

        public int Count { get; set; }

        public string Name { get; set; }
    }
}
