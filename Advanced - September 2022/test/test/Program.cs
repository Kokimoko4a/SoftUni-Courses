using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {

            string outputFilePath = @"..\..\..\output.txt";

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string input = Console.ReadLine();

                while (input!="End")
                {
                    writer.WriteLine(input);
                    input = Console.ReadLine();
                }
            }

        }


    }
}






