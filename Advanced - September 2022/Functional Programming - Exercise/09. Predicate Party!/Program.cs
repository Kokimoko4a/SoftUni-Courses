using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Predicate<string>, List<string>> remove = (names, crit) =>
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (crit(names[i]))
                    {
                        names.Remove(names[i]);
                        i--;
                    }
                }

                return names;
            };


            Func<List<string>, Predicate<string>, List<string>> doubler = (names, crit) =>
            {          
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();

                for (int i = 0; i < names.Count; i++)
                {
                    if (crit(names[i]))
                    {
                        list.Add(names[i]);
                       
                    }

                    else
                    {
                        list2.Add(names[i]);
                        names.Remove(names[i]);
                    }
                }

                names.AddRange(list);
                names.AddRange(list2);

                return names;
            };


         
            List<string> names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command!="Party!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Remove")
                {
                    if (tokens[1] == "StartsWith")
                    {
                        names = remove(names, x => x.StartsWith(tokens[2]));
                    }

                    else if (tokens[1] == "EndsWith")
                    {
                        names = remove(names, x => x.EndsWith(tokens[2]));
                    }

                   else if (tokens[1] == "Length")
                    {
                        names = remove(names, x => x.Length == int.Parse(tokens[2]));                       
                    }
                }

                else if(action == "Double")
                {

                    if (tokens[1] == "StartsWith")
                    {
                        names = doubler(names, x => x.StartsWith(tokens[2]));
                    }

                    else if (tokens[1] == "EndsWith")
                    {
                        names = doubler(names, x => x.EndsWith(tokens[2]));
                    }

                    else if (tokens[1] == "Length")
                    {
                        names = doubler(names, x => x.Length == int.Parse(tokens[2]));
                    }
                }

                command = Console.ReadLine();
            }
          
            if (names.Count>0)
            {
                Console.WriteLine($"{string.Join(", ",names)} are going to the party!");
            }

            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
