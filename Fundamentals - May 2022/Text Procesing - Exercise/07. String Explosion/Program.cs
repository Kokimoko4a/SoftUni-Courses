using System;
using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder finalResult = new StringBuilder();
            int power = 0;  

            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];

                if (curr == '>')
                {
                    power += int.Parse(input[i+1].ToString());
                    finalResult.Append('>');
                }

                else if (power == 0)
                {
                    finalResult.Append(curr);
                }

                else
                {
                    power--;
                }
            }

            Console.WriteLine(finalResult );
        }
    }
}
