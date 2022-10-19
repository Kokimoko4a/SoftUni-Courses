using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }

        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<Player> Roster { get; set; }
        public int Count { get { return Roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (Roster.Any(x => x.Name == name))
            {
                Roster.Remove(Roster.Find(x => x.Name == name));
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (Roster.Any(x => x.Name == name))
            {
                var player = Roster.First(x => x.Name == name);
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (Roster.Any(x => x.Name == name))
            {
                var player = Roster.First(x => x.Name == name);
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classs)
        {
            Player[] kickedPlayers = Roster.Where(x => x.Class == classs).ToArray();

            Roster = Roster.Where(x => x.Class != classs).ToList();

            return kickedPlayers;
        }

        public string Report()
        {
            return $"Players in the guild: {Name}{Environment.NewLine}" +
                string.Join(Environment.NewLine, Roster);

        }
    }

}
