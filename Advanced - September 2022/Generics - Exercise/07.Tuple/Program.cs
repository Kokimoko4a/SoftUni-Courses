using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine().Split();
            Tuple<string, string> tupleForNameAndAdress = new Tuple<string, string>();
            tupleForNameAndAdress.Item1 = string.Join(" ", nameAndAdress[0], nameAndAdress[1]);
            tupleForNameAndAdress.Item2 = string.Join(" ", nameAndAdress.Skip(2));

            string[] nameAndBeer  = Console.ReadLine().Split();
            Tuple<string, int> tupleForNameAndBeer = new Tuple<string, int>();
            tupleForNameAndBeer.Item1 = nameAndBeer[0];
            tupleForNameAndBeer.Item2 = int.Parse(nameAndBeer[1]);

            string[] intDouble = Console.ReadLine().Split();
            Tuple<int, double> tupleIntDouble = new Tuple<int, double>();
            tupleIntDouble.Item1 = int.Parse(intDouble[0]);
            tupleIntDouble.Item2 = double.Parse(intDouble[1]);

            Console.WriteLine($"{tupleForNameAndAdress.Item1} -> {tupleForNameAndAdress.Item2}");
            Console.WriteLine($"{tupleForNameAndBeer.Item1} -> {tupleForNameAndBeer.Item2}");
            Console.WriteLine($"{tupleIntDouble.Item1} -> {tupleIntDouble.Item2}");

        }
    }
}
