using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limiter = int.Parse(Console.ReadLine());
            Predicate<string> isValid = name => name.Length > limiter;

          
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            names.RemoveAll(isValid);
            Console.WriteLine(String.Join(Environment.NewLine,names));
        }
    }
}
