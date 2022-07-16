using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0)
                {
                    if (input[i - 1] == input[i])
                    {
                        continue;
                    }

                    else
                    {
                        sb.Append(input[i]);
                    }
                }

                else
                {
                    sb.Append(input[i]);
                }

            }

            Console.WriteLine(sb);
        }
    }
}
