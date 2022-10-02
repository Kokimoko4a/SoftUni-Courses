using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<Predicate<int>>, List<int>, List<int>> func = (num, match, result) =>
           {
               bool stavaLi = true;

               for (int i = 0; i < num.Count; i++)
               {
                   for (int k = 0; k < match.Count; k++)
                   {
                       if (!match[k](num[i]))
                       {
                           stavaLi = false;
                           break;
                       }
                   }

                   if (stavaLi)
                   {
                       result.Add(num[i]);
                   }
                   stavaLi = true;
               }

               return result;
           };

            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            List<Predicate<int>> isDivisible = new List<Predicate<int>>();
            List<int> result = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);

            }

            foreach (var item in dividers)
            {
                isDivisible.Add(x => x % item == 0);
            }

            result = func(numbers, isDivisible, result);
            Console.WriteLine(String.Join(" ",result));
        }
    }
}
