using System;
using System.Collections.Generic;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (command != "end")
            {
                string[] tokens = command.Split();
             
                Student student = new Student();
                student.FirstName = tokens[0];
                student.LastName = tokens[1];
                student.Age = tokens[2];
                student.HomeTown = tokens[3];
                students.Add(student);

                command = Console.ReadLine();
            }

             command = Console.ReadLine();

            foreach (var student in students )
            {
                if (student .HomeTown == command )
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }

        }
    }

    class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }

}
