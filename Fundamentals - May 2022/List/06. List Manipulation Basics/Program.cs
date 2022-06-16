using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> commannd = new List<string>();
            commannd = Console.ReadLine().Split().ToList ();

            while (commannd[0] !="end")
            {
                switch (commannd[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(commannd[1]);
                        input .Add (numberToAdd);
                        break;

                    case "Remove":
                        int numberToRemove = int.Parse(commannd[1]);
                        input.Remove (numberToRemove);
                        break;

                    case "RemoveAt":
                        int numberToRemoveAt = int.Parse(commannd[1]);
                        input.RemoveAt (numberToRemoveAt);
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(commannd[1]);
                        int numberToInsertAt = int.Parse(commannd[2]);
                        input.Insert (numberToInsertAt ,numberToInsert );
                        break;
                }

                commannd = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(String .Join (" ", input ));
        }
    }
}
