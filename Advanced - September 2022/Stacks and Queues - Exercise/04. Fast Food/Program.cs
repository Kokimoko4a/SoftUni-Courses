using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse ));
            int theBiggestOrder = orders.Max();

            while (orders.Count>0)
            {
                if (quantity - orders.Peek() >=0)
                {                    
                    quantity -= orders.Dequeue();
                }

                else
                {
                    Console.WriteLine(theBiggestOrder);
                    Console.Write($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }
            Console.WriteLine(theBiggestOrder);
            Console.WriteLine("Orders complete");

        }
    }
}
