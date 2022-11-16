using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private List<IVessel> vessels= new List<IVessel>();
        
        public Captain(string fullName)
        {
            FullName= fullName;
            
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get { return vessels.AsReadOnly(); } }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Any())
            {
                foreach (var item in Vessels)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
