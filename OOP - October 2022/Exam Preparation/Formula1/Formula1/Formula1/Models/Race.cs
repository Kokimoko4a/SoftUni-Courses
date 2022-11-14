using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private PilotRepository pilots = new PilotRepository();

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
        }

        public string RaceName
        {
            get { return raceName; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }

                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }

                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get { return (ICollection<IPilot>)pilots.Models; } }

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            /*"The { race name } race has:
             Participants: { number of participants }
            Number of laps: { number of laps }
            Took place: { Yes/No }"
 */
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");

            if (TookPlace)
            {
                sb.Append($"Took place: Yes");
            }

            else
            {
                sb.AppendLine("Took place: No");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
