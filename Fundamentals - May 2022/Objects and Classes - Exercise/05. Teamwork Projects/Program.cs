using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int countOfTeams = int.Parse(Console.ReadLine());
            List<Team> allTeams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] arguments = Console.ReadLine().Split('-');

                //Team currTeam = new Team(arguments[0], arguments[1]);

                if (allTeams.Any(team => team.NameOfTeam == arguments[1]))
                {
                    Console.WriteLine($"Team {arguments[1]} was already created!");
                }

                else if (allTeams.Any(creator => creator.Creator == arguments[0]))
                {
                    Console.WriteLine($"{arguments[0]} cannot create another team!");
                }

                else
                {
                    Team team = new Team();
                    team.Creator = arguments[0];
                    team.NameOfTeam = arguments[1];
                    team.Members = new List<string>();
                    allTeams.Add(team);
                    Console.WriteLine($"Team {arguments[1]} has been created by {arguments[0]}!");
                }
            }

            string[] argumentsForMembers = Console.ReadLine().Split("->");

            while (argumentsForMembers[0] != "end of assignment")
            {


                if (!allTeams.Any(team => team.NameOfTeam == argumentsForMembers[1]))
                {
                    Console.WriteLine($"Team {argumentsForMembers[1]} does not exist!");
                }

                else if (allTeams.Any(team => team.Members.Contains(argumentsForMembers[0])))
                {
                    Console.WriteLine($"Member {argumentsForMembers[0]} cannot join team {argumentsForMembers[1]}!");
                }

                else if (allTeams.Any(team => team.Creator == argumentsForMembers[0]))
                {
                    Console.WriteLine($"Member {argumentsForMembers[0]} cannot join team {argumentsForMembers[1]}!");
                }

                else
                {
                    var currTeam = allTeams.Find(team => team.NameOfTeam == argumentsForMembers[1]);
                    currTeam.Members.Add(argumentsForMembers[0]);

                }


                argumentsForMembers = Console.ReadLine().Split("->");
            }


            foreach (var pr in allTeams.OrderByDescending(m => m.Members.Count).ThenBy(t => t.NameOfTeam).Where(m => m.Members.Count > 0))
            {
                pr.Members.Sort();
                Console.WriteLine($"{pr.NameOfTeam}");
                Console.WriteLine($"- {pr.Creator}");
                Console.Write("-- ");
                Console.WriteLine(string.Join("\r\n-- ", pr.Members));
            }

            Console.WriteLine("Teams to disband:");
            foreach (var pr in allTeams.OrderBy(t => t.NameOfTeam).Where(m => m.Members.Count < 1))
            {
                Console.WriteLine($"{pr.NameOfTeam}");
            }



        }

    }
}

class Team
{


    public string Creator { get; set; }
    public string NameOfTeam { get; set; }
    public List<string> Members { get; set; }



}
