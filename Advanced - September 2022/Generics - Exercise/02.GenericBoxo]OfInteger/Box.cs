using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxo_OfInteger
{
    public class Box<T>
    {
        public Box()
        {
            Box1 = new List<T>();
        }


        public List<T> Box1 { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Box1)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }


}

