using System;
using System.Linq;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            ThreeUple<string, string,string> tupleForNameAndAdress = new ThreeUple<string, string,string>();
            tupleForNameAndAdress.Item1 = string.Join(" ", nameAndAdress[0], nameAndAdress[1]);
            tupleForNameAndAdress.Item2 = nameAndAdress[2];
            tupleForNameAndAdress.Item3 = nameAndAdress[3];

            string[] nameAndBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ThreeUple<string, int,bool> tupleForNameAndBeer = new ThreeUple<string, int,bool>();
            tupleForNameAndBeer.Item1 = nameAndBeer[0];
            tupleForNameAndBeer.Item2 = int.Parse(nameAndBeer[1]);

            if (nameAndBeer[2] == "not")
            {
                tupleForNameAndBeer.Item3 = false;
            }

           

            else

            {
                tupleForNameAndBeer.Item3 = true;
            }

            string[] intDouble = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ThreeUple<string, double,string> tupleIntDouble = new ThreeUple<string, double,string>();
            tupleIntDouble.Item1 = intDouble[0];
            tupleIntDouble.Item2 = double.Parse(intDouble[1]);
            tupleIntDouble.Item3 = intDouble[2];

            Console.WriteLine($"{tupleForNameAndAdress.Item1} -> {tupleForNameAndAdress.Item2} -> {tupleForNameAndAdress.Item3}");
            Console.WriteLine($"{tupleForNameAndBeer.Item1} -> {tupleForNameAndBeer.Item2} -> {tupleForNameAndBeer.Item3}");
            Console.WriteLine($"{tupleIntDouble.Item1} -> {tupleIntDouble.Item2} -> {tupleIntDouble.Item3}");
        }
    }
}
