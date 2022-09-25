using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cofee = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Dictionary<int, Cofee> menu = new Dictionary<int, Cofee>();

            menu.Add(50, new Cofee("Cortado" ,0));
            menu.Add(75, new Cofee("Espresso", 0));
            menu.Add(100, new Cofee("Capuccino", 0));
            menu.Add(150, new Cofee("Americano", 0));
            menu.Add(200, new Cofee("Latte", 0));

            while (cofee.Count > 0 && milk.Count > 0)
            {
                int currCoffe = cofee.Dequeue();
                int currMilk = milk.Pop();
                int caffe = currMilk + currCoffe;

                if (menu.ContainsKey(caffe))
                {
                    menu[caffe].Count++;
                }

                else
                {
                    currMilk -= 5;
                    milk.Push(currMilk);
                }
            }

            if (milk.Count == 0 && cofee.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                // Console.Write(String.Join(", ",cofee));
                Console.WriteLine("Milk left: none");

                foreach (var item in menu.OrderBy(x => x.Value.Count).ThenByDescending(x => x.Value.Name))
                {
                    if (item.Value.Count>0)
                    {
                        Console.WriteLine($"{item.Value.Name}: {item.Value.Count}");
                    }

                    
                }
            }

            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");

                if (cofee.Count > 0)
                {
                    Console.Write("Coffee left: ");
                    Console.WriteLine(String.Join(", ", cofee));
                  
                }

                else
                {
                    Console.WriteLine("Coffee left: none");
                }

                if (milk.Count > 0)
                {
                    Console.Write("Milk left: ");
                    Console.WriteLine(String.Join(", ", milk));
                  
                }

                else
                {
                    Console.WriteLine("Milk left: none");
                }

                foreach (var item in menu.OrderBy(x => x.Value.Count).ThenByDescending(x => x.Value.Name))
                {
                    if (item.Value.Count > 0)
                    {
                        Console.WriteLine($"{item.Value.Name}: {item.Value.Count}");
                    }
                }
            }
        }
        class Cofee
        {
            public Cofee(string name, int count)
            {
                Name = name;
                Count = count;
            }

            public string Name { get; set; }
            public int Count { get; set; }

        }
    }
}



