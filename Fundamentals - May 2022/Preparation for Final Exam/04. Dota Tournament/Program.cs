using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Dota_Tournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Team> teamsInfos = new Dictionary<string, Team>();

            while (command != "Tournament end")
            {
                string[] tokens = command.Split(" -> ");
                string action = tokens[0];
                string nameOfTeam = tokens[1];

                if (action == "New team")
                {
                    string[] members = tokens[2].Split(", ");

                    Team currTeam = new Team(members, 0);

                    teamsInfos.Add(nameOfTeam, currTeam);
                }

                else if (action == "Disqualification ")
                {
                    teamsInfos.Remove(nameOfTeam);
                }

                else if (action == "Win")
                {
                    teamsInfos[nameOfTeam].CountOfWins++;
                }

                command = Console.ReadLine();
            }

            foreach (var team in teamsInfos.OrderByDescending(x => x.Value.CountOfWins))
            {
                //“{ teamName} - { player1, player2,…player5} -> { wins}

                Console.WriteLine($"{team.Key} - {string.Join(", ", team.Value.Members)} -> {team.Value.CountOfWins}");
            }
        }
    }

    class Team
    {
        public Team(string[] members, int countOfWins)
        {
            Members = members;
            CountOfWins = countOfWins;
        }

        public string[] Members { get; set; }
        public int CountOfWins { get; set; }
    }
}
