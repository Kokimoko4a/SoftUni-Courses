using System;
using System.Linq;

namespace _1._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfWagons = int.Parse(Console.ReadLine());
            int[] people = new int[countOfWagons];
            int sum = 0;

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                sum += people[i];
            }

            Console.WriteLine(string.Join(" ", people));
            Console.WriteLine(sum);
        }
    }
}
