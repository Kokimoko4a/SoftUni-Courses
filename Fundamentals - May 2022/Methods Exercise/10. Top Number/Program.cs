using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());

            Divisible(num1);

        }



        private static void Divisible(int num1)
        {
            int sum = 0;
            for (int i = 1; i < num1; i++)
            {
                int copy = i;
                while (copy > 0)
                {
                    sum += copy % 10;
                    copy /= 10;
                }

                if (sum % 8 == 0)
                {
                    int copy2 = i;
                    sum = 0;
                    int counter = 0;
                    while (copy2 >0)
                    {
                        copy2 /= 10;
                       // copy2 /= 10;
                        if (copy2 %2!=0)
                        {
                            counter++;
                        }
                    }
                    if (counter >=1)
                    {
                        Console.WriteLine(i);
                    }


                }
                sum = 0;
            }

            
        }


    }
}
