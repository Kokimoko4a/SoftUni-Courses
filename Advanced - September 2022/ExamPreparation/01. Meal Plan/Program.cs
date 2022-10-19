using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("salad", 350);
            dict.Add("soup", 490);
            dict.Add("pasta", 680);
            dict.Add("steak", 790);
            int eatenMeals = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                string currMeal = meals.Dequeue();
                int currCalories = calories.Peek();

                if (currCalories - dict[currMeal] > 0)
                {
                    calories.Pop();
                    calories.Push(currCalories - dict[currMeal]);

                }

                if (currCalories - dict[currMeal] == 0)
                {
                    calories.Pop();

                }

                else if (currCalories - dict[currMeal] < 0)
                {
                    int left = Math.Abs(currCalories - dict[currMeal]);
                    calories.Pop();

                    if (calories.Count > 0)
                    {
                        int nextCalories = calories.Pop();
                        calories.Push(nextCalories - left);
                    }

                }

                eatenMeals++;
            }


            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {eatenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }

            else
            {
                Console.WriteLine($"John ate enough, he had {eatenMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }

        }
    }
}
