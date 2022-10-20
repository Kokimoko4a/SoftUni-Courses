using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(int[] lake)
        {
            MyLake = lake;
        }

        public int[] MyLake { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
           //MaLake = MyLake.OrderBy()

            for (int i = 0; i < MyLake.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return MyLake[i];
                }
            }

            for (int i = MyLake.Length - 1; i >= 0; i--)
            {
                if (i%2!=0)
                {
                    yield return MyLake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
