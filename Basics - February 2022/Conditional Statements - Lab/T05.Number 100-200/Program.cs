using System;

namespace T05.Number_100_200
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isLess100 = number < 100;
          //  bool 
            bool isBetween100And200 =  number>=100 && number<=200;
            bool isMore200 = number > 200;
            if (isLess100)
            {

                Console.WriteLine("Less than 100");

            }
            else if (isBetween100And200)
            {
                Console.WriteLine("Between 100 and 200");

            }
            else if (isMore200) { 
            
            Console.WriteLine("Greater than 200");
            }
        }
    }
}
