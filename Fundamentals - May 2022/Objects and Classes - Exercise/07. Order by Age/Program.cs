using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();
            List<People> people = new List<People>();

            while (command != "End")
            {
                string[] arguments = command.Split();

                People man = new People(arguments[0], arguments[1], int.Parse(arguments[2]));

                people.Add(man);

                command = Console.ReadLine();
            }

            people = people.OrderBy(man => man.Age).ToList();

            foreach (var man in people )
            {
                Console.WriteLine(man);
            }



        }
    }

    class People
    {
        public People(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"{Name} with ID: {ID} is {Age} years old.";





    }
}

