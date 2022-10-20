using System;
using System.Collections.Generic;

namespace _05.Comparing_Objects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command =Console.ReadLine();

            while (command!="END")
            {
                string[] tokens = command.Split();
                Person person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                people.Add(person);
                command = Console.ReadLine();

            }

            //"{count of matches} {number of not equal people} {total number of people}"
            int indexToCompare = int.Parse(Console.ReadLine());
            Person thePersonToCompare = people[indexToCompare-1];
            int mathes = 0;
            int disMathes = 0;

            foreach (var item in people)
            {
                thePersonToCompare.CompareTo(item);

                if (thePersonToCompare.CompareTo(item) == 0)
                {
                    mathes++;
                }

                else
                {
                    disMathes++;
                }
            }

            mathes--;
            if (mathes==0)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine($"{mathes} {disMathes} {people.Count}");
        }
    }
}
