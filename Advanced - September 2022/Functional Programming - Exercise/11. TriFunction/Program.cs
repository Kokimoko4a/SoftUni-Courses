using System;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isEaqualOrBigger = (name, num) =>

            {
                return name.Sum(ch => ch) >= num;
            };

            Func<string[], int, Func<string, int, bool>, string> print = (names, num, match) =>
            {
                return names.FirstOrDefault(name => match(name,num));
            };

            int target = int.Parse(Console.ReadLine());
            string[] words = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(print(words,target,isEaqualOrBigger));
        }
    }
}
