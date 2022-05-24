using System;

namespace Drawing_Figures_Maika
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int stars = 1; stars <= 2; stars++)
            {
                Console.Write('*');
            }
            for (int spaces = 1; spaces <= n; spaces++)
            {
                Console.Write(' ');
            }
            for (int stars = 1; stars <= 2 * n; stars++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            for (int row = 0; row < n - 2; row++)
            {
                Console.Write('*');

                for (int slashes = 1; slashes <= 2 / n - 2; slashes++)
                {
                    Console.Write('/');


                }
                Console.WriteLine('*');

                int indexOfPipes = (n - 1) / 2 - 1;

                for (int col = 1; col <= n; col++)
                {
                    if (row == indexOfPipes)
                    {
                        Console.Write('|');
                    }

                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.Write('*');

                for (int slashes = 1; slashes <= 2 / n - 2; slashes++)
                {
                    Console.Write('/');


                }
                Console.WriteLine('*');

            }

            for (int stars = 1; stars <= 2; stars++)
            {
                Console.Write('*');
            }
            for (int spaces = 1; spaces <= n; spaces++)
            {
                Console.Write(' ');
            }
            for (int stars = 1; stars <= 2 * n; stars++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            for (int row = 0; row < n - 2; row++)
            {
                Console.Write('*');
            }
        }
    }
}
