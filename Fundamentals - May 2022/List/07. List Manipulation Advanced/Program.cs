using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> commannd = new List<string>();
            commannd = Console.ReadLine().Split().ToList();
            bool IsChanged = false;

            while (commannd[0] != "end")
            {
                switch (commannd[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(commannd[1]);
                        input.Add(numberToAdd);
                        IsChanged = true;
                        break;

                    case "Remove":
                        int numberToRemove = int.Parse(commannd[1]);
                        input.Remove(numberToRemove);
                        IsChanged = true;
                        break;

                    case "RemoveAt":
                        int numberToRemoveAt = int.Parse(commannd[1]);
                        input.RemoveAt(numberToRemoveAt);
                        IsChanged = true;
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(commannd[1]);
                        int numberToInsertAt = int.Parse(commannd[2]);
                        input.Insert(numberToInsertAt, numberToInsert);
                        IsChanged = true;
                        break;

                    case "Contains":
                        int numberToContain = int.Parse(commannd[1]);
                        PrintIfConains(numberToContain, input);
                        break;

                    case "PrintEven":
                        PrintEven(input);
                        break;

                    case "PrintOdd":
                        PrintOdd(input);
                        break;

                    case "GetSum":
                        GetSum(input);
                        break;

                    case "Filter":
                        int number = int.Parse(commannd[2]);
                        PrintFiltered(number, commannd[1], input);
                        break;
                }

                commannd = Console.ReadLine().Split().ToList();
            }
            if (IsChanged )
            {
                Console.WriteLine(String.Join(" ", input));
            }         
        }

        

        private static void PrintIfConains(int numberToContain, List<int> input)
        {
            if (input .Contains (numberToContain ))
            {
                Console.WriteLine("Yes");
            }

            else
            {
                Console.WriteLine("No such number");
            }
        }

        private static void PrintEven(List<int> input)
        {
            foreach (var number in input )
            {
                if (number %2==0)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintOdd(List<int> input)
        {
            foreach (var number in input)
            {
                if (number % 2 != 0)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }

        private static void GetSum(List<int> input)
        {
            int sum = 0;

            foreach (var number in input )
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }

        private static void PrintFiltered(int number, string operation, List<int> input)
        {
            switch (operation )
            {
                case ">":
                    foreach (var item in input )
                    {
                        if (item > number)
                        {
                            Console.Write(item + " " );
                        }
                    }
                    Console.WriteLine();
                    break;



                case ">=":
                    foreach (var item in input)
                    {
                        if (item >= number)
                        {
                            Console.Write(item + " ");
                        }
                    }
                    Console.WriteLine();
                    break;


                case "<":
                    foreach (var item in input)
                    {
                        if (item < number)
                        {
                            Console.Write(item + " ");
                        }
                    }
                    Console.WriteLine();
                    break;


                case "<=":
                    foreach (var item in input)
                    {
                        if (item <= number)
                        {
                            Console.Write(item + " ");
                        }
                    }
                    Console.WriteLine();
                    break;
            }
        }
    }
    }

