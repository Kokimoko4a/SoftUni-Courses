using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1Cnt=0;
            double p2Cnt=0;
            double p3Cnt=0;
            double p4Cnt=0;
            double p5Cnt=0;

            for (int i = 1; i <= n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (currNum <200)
                {
                    p1Cnt++;
                }

                else if (currNum <=399)
                {
                    p2Cnt++;
                }

                else if (currNum <=599)
                {
                    p3Cnt++;
                }

                else if (currNum <=799)
                {
                    p4Cnt++;
                }

                else
                {
                    p5Cnt++;
                }
            }

            double p1 = (p1Cnt / n) * 100;
            double p2 = (p2Cnt / n) * 100;
            double p3 = (p3Cnt / n) * 100;
            double p4 = (p4Cnt / n) * 100;
            double p5 = (p5Cnt / n) * 100;

            Console.WriteLine ($"{p1:f2}%");
            Console.WriteLine ($"{p2:f2}%");
            Console.WriteLine ($"{p3:f2}%");
            Console.WriteLine ($"{p4:f2}%");
            Console.WriteLine ($"{p5:f2}%");
        }
    }
}
