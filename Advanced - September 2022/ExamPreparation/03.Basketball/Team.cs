using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.Count = 0;
            this.Players = new List<Player>();
        }

        private List<Player> players;
        private string name;
        private int openPositions;
        private char group;
        private int count;



        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        public char Group
        {
            get { return group; }
            set { group = value; }
        }

        public int OpenPositions
        {
            get { return openPositions; }
            set { openPositions = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Name == string.Empty || player.Position == null || player.Position == string.Empty)
            {
                return $"Invalid player's information.";
            }

            else if (OpenPositions > 0)
            {

                if (player.Rating < 80)
                {
                    return $"Invalid player's rating.";
                }

                else
                {
                    OpenPositions--;
                    Count++;
                    Players.Add(player);
                    return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
                }

            }

            else
            {
                return $"There are no more open positions.";
            }
        }

        public bool RemovePlayer(string name)
        {
            // bool isHere = false;

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Name == name)
                {
                    Players.Remove(Players[i]);
                    OpenPositions++;
                    Count--;
                    return true;

                }
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Position == position)
                {
                    Players.RemoveAt(i);
                    OpenPositions++;
                    Count--;
                    i--;
                    count++;
                }
            }

            return count;
        }

        public Player RetirePlayer(string name)
        {

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Name == name)
                {
                    Players[i].Retired = true;
                    return Players[i];
                }
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> players = new List<Player>();

            foreach (var player in Players)
            {
                if (player.Games >= games)
                {
                    players.Add(player);
                }
            }

            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team BHTC from Group {Group}:");

            for (int i = 0; i < Players.Count; i++)
            {
                if (!Players[i].Retired)
                {
                    if (i + 1 == Players.Count)
                    {
                        sb.AppendLine($"-Player: {Players[i].Name}");
                        sb.AppendLine($"--Position: {Players[i].Position}");
                        sb.AppendLine($"--Rating: {Players[i].Rating}");
                        sb.Append($"--Games played: {Players[i].Games}");
                        break;
                    }

                    else
                    {
                        sb.AppendLine($"-Player: {Players[i].Name}");
                        sb.AppendLine($"--Position: {Players[i].Position}");
                        sb.AppendLine($"--Rating: {Players[i].Rating}");
                        sb.Append($"--Games played: {Players[i].Games}");
                        sb.AppendLine();
                    }

                }
            }

            return sb.ToString().TrimEnd();
        }


    }
}
