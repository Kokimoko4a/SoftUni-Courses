using System;

namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int allEmployees = first + second + third;
            int hours = 0;
            int i = 0;
            

            while (studentsCount > 0)
            {

                int zaSravnenie = hours + 1;

                if (zaSravnenie  % 4 == 0 && i > 0)
                {
                    hours++;
                    continue;
                }

                studentsCount -= allEmployees;
                hours++;
                i++;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
