using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            Pizza pizza = new Pizza();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] arguments = command.Split();

                if (arguments[0] == "Dough")
                {
                    try
                    {
                        List<string> wishes = new List<string>();

                        foreach (var item in arguments.Skip(1))
                        {
                            if (!char.IsDigit(item[0]))
                            {
                                wishes.Add(item.ToLower());
                            }
                        }

                        Dough dough = new Dough(wishes, double.Parse(arguments[arguments.Length - 1]));

                        pizza.Dough = dough;
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }

                }

                else if (arguments[0] == "Topping")
                {
                    try
                    {
                        string theTopping = arguments[1];


                        Topping topping = new Topping(theTopping, double.Parse(arguments[arguments.Length - 1]));
                        pizza.AddTopping(topping);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }

                }

                else if (arguments[0] == "Pizza")
                {
                    try
                    {
                        Pizza pizza2 = new Pizza(arguments[1]);
                        pizza = pizza2;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }     
            } 
            if (pizza.Name != null)
            {
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }          
        }
    }
}
