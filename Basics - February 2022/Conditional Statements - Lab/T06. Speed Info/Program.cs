using System;

namespace T06._Speed_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            double velocity = double.Parse(Console.ReadLine());

            if (velocity <= 10)
            {

                Console.WriteLine("slow");
            }
            else if (velocity > 10 && velocity <= 50)
            {
                Console.WriteLine("average");

            }
            else if (velocity > 50 && velocity <= 150)
            {

                Console.WriteLine("fast");
            }
            else if (velocity > 150 && velocity <= 1000) {
                Console.WriteLine("ultra fast");

            }
            else if (velocity>1000) {
                Console.WriteLine(" extremely fast");
            }
        }
    }
}
