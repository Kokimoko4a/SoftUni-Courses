using System;

namespace T01._Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

          //bool isExcellent = grade >= 5.50;
            if (grade>=5.50 ) {
                Console.WriteLine("Excellent!" );
            }
        }
    }
}
