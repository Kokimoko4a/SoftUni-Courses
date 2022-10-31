using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            bool isNull = true;

            for (int i = 0; i < arguments.Length; i++)
            {
                isNull = false;
                string[] currPersonAndMoney = arguments[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                string currName = currPersonAndMoney[0];
                int money = int.Parse(currPersonAndMoney[1]);

                try
                {
                    Person currPerson = new Person(currName, money);
                    people.Add(currPerson);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            if (isNull)
            {
                Console.WriteLine("Name cannot be empty");
                return;
            }

            string[] argumentsForProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < argumentsForProducts.Length; i++)
            {
                string[] currNameAndCost = argumentsForProducts[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                string name = currNameAndCost[0];
                int currCost = int.Parse(currNameAndCost[1]);

                try
                {
                    Product product = new Product(name, currCost);
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string command = Console.ReadLine();

            while (command!="END")
            {
                string[] manAndProduct = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = manAndProduct[0];
                string productName = manAndProduct[1];

                if (people.FirstOrDefault(x=>x.Name == name) !=null)
                {
                    Person person = people.Find(x => x.Name == name);

                    if (person.Money>products.Find(x=>x.Name == productName).Cost)
                    {
                        person.Money-=products.Find(x=>x.Name == productName).Cost;
                        Console.WriteLine($"{name} bought {productName}");
                        person.BagOfProducts.Add(products.Find(x => x.Name == productName));
                    }

                    else
                    {
                        Console.WriteLine($"{name} can't afford {productName}");
                    }
                }

                command = Console.ReadLine();     
            }

            foreach (var person in people)
            {
                List<string> currPriductsNames = new List<string>();

                foreach (var item in person.BagOfProducts)
                {
                    currPriductsNames.Add(item.Name);
                }

                if (currPriductsNames.Count==0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }


                else
                {
                     Console.WriteLine($"{person.Name} - {string.Join(", ",currPriductsNames)}");
                }
               
            }
        }
    }
}
