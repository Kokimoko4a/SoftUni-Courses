using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels = new VesselRepository();
        private ICollection<ICaptain> captains = new List<ICaptain>();

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (captains.FirstOrDefault(x => x.FullName == selectedCaptainName) == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            if (vessels.Models.FirstOrDefault(x => x.Name == selectedVesselName) == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            Vessel currVessel = (Vessel)vessels.Models.FirstOrDefault(x => x.Name == selectedVesselName);

            if (currVessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            Captain captain = (Captain)captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            currVessel.Captain = captain;
            captain.AddVessel(currVessel);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            if (vessels.Models.FirstOrDefault(x => x.Name == attackingVesselName) == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            if (vessels.Models.FirstOrDefault(x => x.Name == defendingVesselName) == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            Vessel attackingVessel = (Vessel)vessels.Models.FirstOrDefault(x => x.Name == attackingVesselName);
            Vessel defendingVessel = (Vessel)vessels.Models.FirstOrDefault(x => x.Name == defendingVesselName);

            if (attackingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";

        }

        public string CaptainReport(string captainFullName)
        {      
            var captain =  captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.FirstOrDefault(x => x.FullName == fullName) == null)
            {
                Captain captain = new Captain(fullName);
                captains.Add(captain);
                return $"Captain {fullName} is hired.";
            }

            else
            {
                return $"Captain {fullName} is already hired.";
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.Models.FirstOrDefault(x => x.Name == name) != null)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }

            Vessel vessel = null;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }

            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }

            else
            {
                return "Invalid vessel type.";
            }

            vessels.Add(vessel);
            return $"{vessel.GetType().Name} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            if (vessels.Models.FirstOrDefault(x => x.Name == vesselName) == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            Vessel vessel = (Vessel)vessels.Models.FirstOrDefault(x => x.Name == vesselName);
            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            if (vessels.Models.FirstOrDefault(x => x.Name == vesselName) == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            Vessel currVessel = (Vessel)vessels.Models.FirstOrDefault(x => x.Name == vesselName);

            if (currVessel is Battleship)
            {
                Battleship battleship = currVessel as Battleship;
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }

            else
            {
                Submarine submarine = currVessel as Submarine;
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string VesselReport(string vesselName)
        {
            return vessels.FindByName(vesselName).ToString();
        }
    }
}
