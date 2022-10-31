using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {
            this.Age = 1;
            this.Name = "No name";
        }
        public Person(int age)
        {
            this.Age = age;
            this.Name = "No name";
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private int age;
        private string name;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
