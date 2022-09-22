using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (!studentsGrades.ContainsKey(tokens[0]))
                {
                    studentsGrades.Add(tokens[0], new List<decimal>());
                }

                studentsGrades[tokens[0]].Add(decimal.Parse(tokens[1]));
            }

            foreach (var item in studentsGrades)
            {
                Console.Write($"{item.Key} -> ");
                //Console.Write(String.Join(" ", studentsGrades[item.Key]));

                foreach (var grade in studentsGrades[item.Key])
                {
                    Console.Write($"{ grade:f2} " );
                }

                Console.Write($"(avg: {studentsGrades[item.Key].Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
