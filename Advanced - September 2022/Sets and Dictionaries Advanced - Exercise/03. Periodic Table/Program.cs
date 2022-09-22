using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> chemicalEelements = new HashSet<string>();
            int countOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInput; i++)
            {
                string[] elementOrElements = Console.ReadLine().Split();

                foreach (var element in elementOrElements)
                {
                    chemicalEelements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalEelements.OrderBy(x=>x)));
        }
    }
}
