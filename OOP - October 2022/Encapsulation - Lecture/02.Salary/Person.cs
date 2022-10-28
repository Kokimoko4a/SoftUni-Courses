using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string fisrtName, string lastName, int age, decimal salary)
        {
            FirstName = fisrtName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age>30)
            {
                Salary += Salary * percentage/100;
            }

            else
            {
                percentage /= 2;

                Salary += Salary * percentage/100;
            }
        }
    }
}
