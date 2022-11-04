using _06.FoodShortage.IO.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
