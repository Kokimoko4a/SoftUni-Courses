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
            //index = stack.Count-1;
        }

        public T Pop()
        {
            if (stack.Count>0)
            {

                T itemToPop =  stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                return itemToPop;

            }

            throw new InvalidOperationException("No elements");
        }

        public void Push(T[] items)
        {
            stack.AddRange(items);
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
