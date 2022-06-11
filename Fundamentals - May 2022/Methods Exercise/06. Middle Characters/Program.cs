using System;
using System.Linq;
namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
           PrintMiddle(input);
      
        }

        private static void PrintMiddle(string input)
        {
            int middle = 1;
            char[] middlearr = new char[2];
            
                if (input.Length %2!=0)
                {
                    middle = input.Length / 2; 
                }

            else
            {
                middlearr[1] = input[input.Length / 2];
                middlearr[0] = input[input.Length /2 - 1];
                Console.WriteLine(String.Join("",middlearr));
                return;
             
            }

            Console.WriteLine(input[middle]);
            
        }
    }
}
