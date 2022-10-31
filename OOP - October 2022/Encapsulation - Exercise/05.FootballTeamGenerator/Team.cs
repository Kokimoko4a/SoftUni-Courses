using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players = new List<Player>();

        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Count > 0)
                {
                    return players.Average(x => x.OverallSkillLevel);
                }

                else
                {
                    return 0;
                }
            }
        }

        public void AddPLayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (players.FirstOrDefault(x => x.Name == name) != null)
            {
                players.Remove(players.Find(x => x.Name == name));
            }

            else
            {
                throw new ArgumentException($"Player {name} is not in {Name} team.");
            }
        }
    }
}
