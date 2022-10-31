using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Town { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }



        public int CompareTo(Person other)
        {
             int isAge = Age.CompareTo(other.Age);
            int isTown = Town.CompareTo(other.Town);
            int isName = Name.CompareTo(other.Name);

            if (isAge==0  && isTown == 0 && isName == 0)
            {
                return 0;
            }

            return -1;
        }
    }
}

