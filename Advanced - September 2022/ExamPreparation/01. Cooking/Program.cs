using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Meal
    {
        public Meal(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; set; }
        public int Count { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<int, Meal> meals = new Dictionary<int, Meal>();
            meals.Add(25,new Meal("Bread",0));
            meals.Add(50,new Meal("Cake",0));
            meals.Add(75,new Meal("Pastry",0));
            meals.Add(100,new Meal("Fruit Pie",0));


            while (liquids.Count>0 && ingredients.Count>0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();

                int sum = liquid + ingredient;

                if (meals.ContainsKey(sum))
                {
                    meals[sum].Count++;
                }

                else
                {
                    ingredient += 3;
                    ingredients.Push(ingredient);
                }
            }

            if (meals.All(x=>x.Value.Count>0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count>0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }

            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count>0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ",ingredients)}");
            }

            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var item in meals.OrderBy(x=>x.Value.Name))
            {
                Console.WriteLine($"{item.Value.Name}: {item.Value.Count}");
            }
        }
    }
}
