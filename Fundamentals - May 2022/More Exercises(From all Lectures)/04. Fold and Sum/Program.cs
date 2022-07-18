using System;
using System.Linq;
namespace _04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] output = new int[input.Length / 2];
            int[] folded1 = new int[input.Length / 2];
            int eachstrana = input.Length / 4;
            int foldForFirst = eachstrana - 1;
            for (int i = 0; i < eachstrana; i++)
            {
                folded1[i] = input[foldForFirst];
                foldForFirst--;
            }

            int[] folded3 = new int[input.Length - folded1.Length];
            int zaOtzad = 1;
            int eachstrana2 = input.Length / 4;

            for (int i = 0; i < eachstrana2; i++)
            {
                folded1[eachstrana] = input[input.Length - zaOtzad];
                zaOtzad++;
                eachstrana++;
            }

            int k = 0;

            for (int i = 0; i < folded3.Length; i++)
            {
                folded3[k] = input[(input.Length / 4) + k];
                k++;
            }

            for (int i = 0; i < folded1.Length; i++)
            {
                output[i] = folded1[i] + folded3[i];
            }

            Console.WriteLine(String.Join("", output));

        }
    }
}
