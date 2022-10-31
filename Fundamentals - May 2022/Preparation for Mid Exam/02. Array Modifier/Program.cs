using System;
using System.Linq;

namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "swap")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);
                    int changingHelper = index1;

                    changingHelper = input[index1];
                    input[index1] = input[index2];
                    input[index2] = changingHelper;

                }

                else if (action == "multiply")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    input[index1] = input[index1] * input[index2];
                }

                else if (action == "decrease")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i]--;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", input));
        }
    }
}
