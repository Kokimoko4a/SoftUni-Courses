using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int whatToDo = 0;
            List<Animal> animals = new List<Animal>();

            while (command != "End")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (whatToDo % 2 == 0)
                {

                    string type = arguments[0];

                    Animal animal = null;

                    if (type == "Cat")
                    {
                        animal = new Cat(arguments[1], double.Parse(arguments[2]), arguments[3], arguments[4]);
                    }

                    else if (type == "Tiger")
                    {
                        animal = new Tiger(arguments[1], double.Parse(arguments[2]), arguments[3], arguments[4]);
                    }

                    else if (type == "Dog")
                    {
                        animal = new Dog(arguments[1], double.Parse(arguments[2]), arguments[3]);
                    }

                    else if (type == "Mouse")
                    {
                        animal = new Mouse(arguments[1], double.Parse(arguments[2]), arguments[3]);
                    }

                    else if (type == "Hen")
                    {
                        animal = new Hen(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]));
                    }

                    else if (type == "Owl")
                    {
                        animal = new Owl(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]));
                    }

                    if (animal != null)
                    {
                        animals.Add(animal);
                    }

                }

                else
                {
                    Console.WriteLine(animals[animals.Count - 1].AskForFood());

                    string type = arguments[0];

                    if (animals[animals.Count - 1] is Hen)
                    {
                        animals[animals.Count - 1].Weight += int.Parse(arguments[1]) * 0.35;
                        animals[animals.Count - 1].FoodEaten += int.Parse(arguments[1]);
                    }

                    else if (animals[animals.Count - 1] is Owl || animals[animals.Count - 1] is Dog || animals[animals.Count - 1] is Tiger)
                    {
                        if (type == "Meat")
                        {
                            if (animals[animals.Count - 1] is Owl)
                            {
                                animals[animals.Count - 1].Weight += int.Parse(arguments[1]) * 0.25;
                            }

                            else if (animals[animals.Count - 1] is Dog)
                            {
                                animals[animals.Count - 1].Weight += int.Parse(arguments[1]) * 0.40;
                            }

                            else if (animals[animals.Count - 1] is Tiger)
                            {
                                animals[animals.Count - 1].Weight += int.Parse(arguments[1]) * 1.00;
                            }
                            animals[animals.Count - 1].FoodEaten += int.Parse(arguments[1]);


                        }

                        else
                        {
                            Console.WriteLine($"{animals[animals.Count - 1].GetType().Name} does not eat {type}!");
                        }


                    }

                    else if (animals[animals.Count - 1] is Mouse)
                    {
                        if (type == "Fruit" || type == "Vegetable")
                        {
                            animals[animals.Count - 1].Weight += int.Parse(arguments[1]) * 0.10;

                            animals[animals.Count - 1].FoodEaten += int.Parse(arguments[1]);
                        }

                        else
                        {
                            Console.WriteLine($"{animals[animals.Count - 1].GetType().Name} does not eat {type}!");
                        }
                    }

                    else if (animals[animals.Count - 1] is Cat)
                    {
                        if (type == "Meat" || type == "Vegetable")
                        {
                            animals[animals.Count - 1].Weight += int.Parse(arguments[1]) * 0.30;

                            animals[animals.Count - 1].FoodEaten += int.Parse(arguments[1]);
                        }

                        else
                        {
                            Console.WriteLine($"{animals[animals.Count - 1].GetType().Name} does not eat {type}!");
                        }
                    }
                }

                command = Console.ReadLine();
                whatToDo++;

            }

            foreach (var animal in animals)
            {
                if (animal is Bird)
                {
                    Bird bird = animal as Bird;

                    Console.WriteLine($"{animal.GetType().Name} [{bird.Name}, {bird.WingSize}, {bird.Weight}, {bird.FoodEaten}]");
                }

                else if (animal is Feline)
                {
                    Feline feline = animal as Feline;

                    Console.WriteLine($"{animal.GetType().Name} [{animal.Name}, {feline.Breed}, {feline.Weight}, {feline.LivingRegion}, {feline.FoodEaten}]");
                }

                else if (animal is Mouse)
                {
                    Mouse mouse = animal as Mouse;

                    Console.WriteLine($"{animal.GetType().Name} [{animal.Name}, {mouse.Weight}, {mouse.LivingRegion}, {mouse.FoodEaten}]");
                }

                else if (animal is Dog)
                {
                    Dog dog = animal as Dog;

                    Console.WriteLine($"{animal.GetType().Name} [{animal.Name}, {dog.Weight}, {dog.LivingRegion}, {dog.FoodEaten}]");
                }
            }
        }
    }
}
