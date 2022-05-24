using System;

namespace _03._Combinations
{
    class Program
    {
        static void Main(string[] args)
        {

            int magicNum = int.Parse(Console.ReadLine());
            int combination = 0;

            for (int x1 = 0; x1 <=magicNum ; x1++)
            {
                for (int x2 = 0; x2 <= magicNum ; x2++)
                {
                    for (int x3 = 0; x3 <= magicNum ; x3++)
                    {
                        if (x1+x2+x3==magicNum )
                        {
                            combination++;

                        }
                    }
                }
            }
            Console.WriteLine(combination );
        }
    }
}
