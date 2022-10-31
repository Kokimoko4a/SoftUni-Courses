using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
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

        public void Swap(int first, int second)
        {
            if (first >= 0 && first < Box1.Count && second >= 0 && second < Box1.Count)
            {
                T temp = Box1[first];
                Box1 [first] = Box1[second];
                Box1[second] = temp;
            }
        }
    }
}
