using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;
        private int index;

        public Stack(List<T> stack)
        {
            this.stack = stack;    
            index = stack.Count-1;
        }

        public T Pop()
        {
            if (stack.Count>0)
            {
                
                return stack[index--];
               
            }

            throw new InvalidOperationException("No elements");
        }

        public void Push(T[] items)
        {
            stack.AddRange(items);
            index+=items.Length;
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in stack)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
