using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class ThreeUple<T1,T2,T3>
    {
        public T3 Item3 { get; set; }
        public T2 Item2 { get; set; }
        public T1 Item1 { get; set; }
    }
}
