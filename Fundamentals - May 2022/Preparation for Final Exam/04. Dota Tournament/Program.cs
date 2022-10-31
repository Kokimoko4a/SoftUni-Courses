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
                string[] tokens = command.Split(new[] { " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length >= 2)
                {
                    string action = tokens[0];
                    string nameOfTeam = tokens[1];

                    if (action == "New team")
                    {
                        if (tokens.Length == 7)
                        {
                            List<string> members = new List<string>();

                            for (int i = 0; i < 5; i++)
                            {
                                members.Add(tokens[i + 2]);
                            }

                            Team currTeam = new Team(members, 0);

                            teamsInfos.Add(nameOfTeam, currTeam);
                        }
                    }

                    else if (action == "Disqualification")
                    {
                        if (teamsInfos.ContainsKey(nameOfTeam))
                        {
                            teamsInfos.Remove(nameOfTeam);
                        }

                    }

                    else if (action == "Win")
                    {
                        if (teamsInfos.ContainsKey(nameOfTeam))
                        {
                            teamsInfos[nameOfTeam].CountOfWins++;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Teams:");

            foreach (var team in teamsInfos.OrderByDescending(x => x.Value.CountOfWins))
            {
                //“{ teamName} - { player1, player2,…player5} -> { wins}

                Console.WriteLine($"{team.Key} - {string.Join(", ", team.Value.Members)} -> {team.Value.CountOfWins} wins");
            }
        }
    }

    class Team
    {
        public Team(List<string> members, long countOfWins)
        {
            Members = members;
            CountOfWins = countOfWins;
        }

        public List<string> Members { get; set; }
        public long CountOfWins { get; set; }
    }
}
