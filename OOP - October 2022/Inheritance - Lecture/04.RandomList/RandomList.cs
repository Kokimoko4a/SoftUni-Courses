using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public int indexToRemoveAt = 0;

        public RandomList()
        {
            Random random = new Random();
            indexToRemoveAt = random.Next(0,this.Count);
        }

        public string RandomString() 
        {
            string removedString = this[indexToRemoveAt];
            this.RemoveAt(indexToRemoveAt);
            return removedString;
        }
    }
}
