using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currNum = 1;
            bool stop = false;
            
            for (int rowNum = 1; rowNum <= n; rowNum++)
            {
                for (int col = 0; col < rowNum; col++)
                {
                    Console.Write(currNum + " ");
                    currNum++;

                    if (currNum>n)
                    {
                        stop = true;
                        break;
                    }

                }

                if (stop == true)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
