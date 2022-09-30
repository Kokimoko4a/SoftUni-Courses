using System;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> writer = w => Console.WriteLine(string.Join(Environment.NewLine,w)); ;
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            writer(words);
        }
    }
}
