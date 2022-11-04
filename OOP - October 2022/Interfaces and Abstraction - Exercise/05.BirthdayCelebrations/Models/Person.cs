using _05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations.Models
{
    public class Person : IBirthtable
    {
        public Person(string name,  int age, string id, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }
       
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
