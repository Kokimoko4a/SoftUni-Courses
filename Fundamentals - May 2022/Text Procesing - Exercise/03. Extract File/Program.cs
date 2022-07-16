using System;
using System.Text;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] path = Console.ReadLine().Split(".");
            string fileName = path[0];
            string fileExtension = path[1];
            StringBuilder fileNameOnly = new StringBuilder();

            for (int i = fileName.Length - 1; i >= 0; i--)
            {
                char currLetter = fileName[i];

                if (char.IsLetterOrDigit(currLetter) || currLetter == '_' || currLetter == '-')
                {
                    fileNameOnly.Append(currLetter);
                }

                else
                {
                    break;
                }
            }

            StringBuilder fileNameOnlyReversed = new StringBuilder();

            for (int i = fileNameOnly.Length - 1; i >= 0; i--)
            {
                fileNameOnlyReversed.Append(fileNameOnly[i]);
            }

            //File name: Template
            // File extension: pptx

            Console.WriteLine($"File name: {fileNameOnlyReversed}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
