using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> startsWithCapital = x => char.IsUpper(x[0]);
            string[] words = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(x=>startsWithCapital(x)).ToArray();
            Console.WriteLine(String.Join(Environment.NewLine,words));
            
            
        }
    }
}
