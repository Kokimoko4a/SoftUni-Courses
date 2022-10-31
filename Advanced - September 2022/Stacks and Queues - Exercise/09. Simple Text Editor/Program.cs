using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfOparations = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string text = string.Empty;
            stack.Push(string.Empty);

            for (int i = 0; i < countOfOparations; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0];

                if (action == "1")
                {
                    string textToAppend = tokens[1];
                    text += textToAppend;
                    stack.Push(text);                  
                }

                else if (action == "2")
                {
                    int countOfElementsToDelete = int.Parse(tokens[1]);
                    text = text.Remove(text.Length - countOfElementsToDelete, countOfElementsToDelete);
                    stack.Push(text);
                }

                else if (action == "3")
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index - 1]);
                }

                else if (action == "4")
                {
                    stack.Pop();
                    text = stack.Peek();
                }
            }
        }
    }
}
