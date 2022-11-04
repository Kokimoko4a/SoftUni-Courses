using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.IO.InterFaces
{
    public interface IWriter
    {
        void Write(string text);    
        void WriteLine(string text);    
    }
}
