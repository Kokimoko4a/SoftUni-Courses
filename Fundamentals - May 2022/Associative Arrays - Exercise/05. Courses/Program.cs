using System;
using System.Collections.Generic;

namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] arguments = command.Split(" : ");
                string nameOfCourse = arguments[0];
                string nameOfStudent = arguments[1];

                if (!courses.ContainsKey(nameOfCourse))
                {
                    courses.Add(nameOfCourse, new List<string>());
                }
                courses[nameOfCourse].Add(nameOfStudent);

                command = Console.ReadLine();
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course .Value )
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
