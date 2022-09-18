using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            int b = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    indexes.Push(i);

                    b++;
                }
                

                else 
                {
                    if (indexes.Count>0)
                    {
                        int currIndex = indexes.Peek();
                        char symbolStack = input[currIndex];

                        if (symbol == ')' && symbolStack == '(')
                        {
                            indexes.Pop();                          
                        }

                        else if (symbol == '}' && symbolStack == '{')
                        {
                            indexes.Pop();
                          
                        }

                        else if (symbol == ']' && symbolStack == '[')
                        {
                            indexes.Pop();
                        }

                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        b++;
                    }      
                }
                
            }
            if (indexes.Count==0 && b == input.Length)
            {
                Console.WriteLine("YES");
            }

            else Console.WriteLine("NO");
         
        }
    }
}
    

