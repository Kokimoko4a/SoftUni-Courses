using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Box1 = new List<T>();
        }
        public List<T> Box1 { get; set; }
        public int d { get; set; }

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
                Box1[first] = Box1[second];
                Box1[second] = temp;
               
            }
        }

        public int CompareTo(T other)
        {
            int count = 0;

            foreach (var item in Box1)
            {
                if (item.CompareTo(other) ==1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
