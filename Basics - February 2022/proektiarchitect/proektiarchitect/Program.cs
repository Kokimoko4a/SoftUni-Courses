using System;

namespace proektiarchitect
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int CountOfProjects = int.Parse(Console.ReadLine());
            int WorkForOneProject = 3;
            int needhours = CountOfProjects * WorkForOneProject;
            Console.WriteLine($"The architect {name} will need {needhours} hours to complete {CountOfProjects} project/s.");
        }
    }
}
