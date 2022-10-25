﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> 
    {
        private T[] list;
        private int index;

        public ListyIterator(T[] list)
        {
            this.list = list;
            index = 0;
        }


        
        public bool HasNext()
        {
            if (index+1<list.Length)
            {
                return true;
            }

            return false;
        }

        public bool Move()
        {
            if (index<list.Length -1)
            {
                index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (list.Length==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            else
            {
                Console.WriteLine(list[index]);
            }
        
        }
    }
}