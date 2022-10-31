using System;
using System.Linq;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                box.Box1.Add(Console.ReadLine());
            }

            string itemToCompareTo = Console.ReadLine();

            Console.WriteLine(box.CompareTo(itemToCompareTo) ); 

            
        }
    }
}
