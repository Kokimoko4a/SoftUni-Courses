using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfFamilyMembers = int.Parse(Console.ReadLine());
            Family family = new Family();
            family.People = new System.Collections.Generic.List<Person>();

            for (int i = 0; i < countOfFamilyMembers; i++)
            {
                string[] currArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(currArgs[0], int.Parse(currArgs[1]));
                family.AddMemeber(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
