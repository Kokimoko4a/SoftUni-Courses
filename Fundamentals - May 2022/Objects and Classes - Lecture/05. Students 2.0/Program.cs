using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();
            bool isFound = false;


            while (command != "end")
            {
                string[] tokens = command.Split();

                foreach (var student2 in students)
                {
                    if (student2.FirstName == tokens[0] && student2.LastName == tokens[1])
                    {
                        student2.Age = tokens[2];
                        student2.HomeTown = tokens[3];
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    command = Console.ReadLine();
                    isFound = false;
                    continue;
                }
                

                Student student = new Student();
                student.FirstName = tokens[0];
                student.LastName = tokens[1];
                student.Age = tokens[2];
                student.HomeTown = tokens[3];

                students.Add(student);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.HomeTown == command)
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
