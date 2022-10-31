using System;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                box.Box1.Add(double.Parse(Console.ReadLine()));
            }

            double itemToCompareTo = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CompareTo(itemToCompareTo));
        }
    }
}
