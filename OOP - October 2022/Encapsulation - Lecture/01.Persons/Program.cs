using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();


            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(arguments[0], arguments[1], int.Parse(arguments[2]));
                people.Add(person);
            }

            people.OrderBy(x => x.FirstName).ThenBy(x => x.Age).ToList().ForEach(p=> Console.WriteLine(p.ToString()));
        }
    }
}
