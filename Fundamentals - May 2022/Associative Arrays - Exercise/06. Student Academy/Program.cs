using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsWithGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsWithGrades.ContainsKey(name))
                {
                    studentsWithGrades[name] = new List<double>();
                }

                studentsWithGrades[name].Add(grade);
            }

            foreach (var student in studentsWithGrades)
            {
                if (student.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }
        }
    }
}
