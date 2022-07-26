using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int coutOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();
            family.FamilyMembers = new List<Person>();

            for (int i = 0; i < coutOfPeople; i++)
            {                
                string[] arguments = Console.ReadLine().Split();
                string name = arguments[0];
                int age = int.Parse(arguments[1]);

                family.AddMember(name, age);
            }
            int theOldest = family.TheOldest();
            foreach (var person in family.FamilyMembers)
            {
                if (person.Age == theOldest)
                {
                    Console.WriteLine(person.Name + " " + person.Age);
                    break;
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {
        public List<Person> FamilyMembers { get; set; }

        public void AddMember(string name, int age)
        {
            Person currPerson = new Person();
            currPerson.Name = name;
            currPerson.Age = age;
            FamilyMembers.Add(currPerson);
        }

        public int TheOldest()
        {
            return FamilyMembers.Max(x=>x.Age );
        }
    }


}
