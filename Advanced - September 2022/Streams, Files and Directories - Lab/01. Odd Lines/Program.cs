using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {

                    int countLine = 0;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (!(countLine % 2 == 0))
                        {
                            writer.WriteLine(line);
                        }

                        countLine++;
                    }
                }

            }
        }
    }
}

