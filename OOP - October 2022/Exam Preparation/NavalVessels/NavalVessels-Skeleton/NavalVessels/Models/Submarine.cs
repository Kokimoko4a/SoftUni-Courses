using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {         
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == true)
            {
                SubmergeMode = false;
                Speed += 4;
                MainWeaponCaliber -= 40;
            }

            else
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (SubmergeMode)
            {
                sb.AppendLine(" *Submerge mode: ON");
            }

            else
            {
                sb.AppendLine(" *Submerge mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
