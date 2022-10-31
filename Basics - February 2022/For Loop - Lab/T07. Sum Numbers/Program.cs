using System;

namespace T07._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int index = 0; index <countOfInputs; index++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                
            }
            Console.WriteLine(sum);
        }
    }
}
