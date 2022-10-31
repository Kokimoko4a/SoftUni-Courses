using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (int.Parse(arguments[1]) >30)
                {
                    people.Add(new Person(arguments[0], int.Parse(arguments[1])));
                }
              
            }

            people = people.OrderBy(x=>x.Name).ToList();

            foreach (var item in people)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}


