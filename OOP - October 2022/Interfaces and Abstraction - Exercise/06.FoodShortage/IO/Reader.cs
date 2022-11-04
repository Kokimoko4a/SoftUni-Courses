using _06.FoodShortage.IO.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
           return Console.ReadLine();
        }
    }
}
