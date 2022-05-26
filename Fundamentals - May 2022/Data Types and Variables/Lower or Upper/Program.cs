using System;

namespace Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string smth = Console.ReadLine();
            string smth2 = smth.ToLower();
            if (smth != smth2)
            {
                Console.WriteLine("upper-case");
            }

            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
