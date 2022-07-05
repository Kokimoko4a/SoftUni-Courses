using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int countOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] command = Console.ReadLine().Split();
                Student student = new Student(command[0], command[1], double.Parse(command[2]));
                students.Add(student);

            }

            students = students.OrderByDescending(student => student.Grade).ToList();


            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString() => $"{FirstName} {LastName}: {Grade:f2}";

    }
}
