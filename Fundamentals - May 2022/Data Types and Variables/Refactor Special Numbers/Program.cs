using System;

namespace Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;
            
            bool isSpecial = false;
            for (int i = 1; i <= count; i++)
            {
                sum = 0;
                int digit = i;
                while (digit  != 0)
                {
                    sum += digit  % 10;
                    digit  = digit  / 10;
                }

                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecial);
                
               

            }
        }
    }
}
