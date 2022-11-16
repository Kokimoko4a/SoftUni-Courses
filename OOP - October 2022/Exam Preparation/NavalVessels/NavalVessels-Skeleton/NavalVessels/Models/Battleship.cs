using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel , IBattleship
    {

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            SonarMode= false;
        }


        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (SonarMode == true)
            {
                SonarMode = false;
                Speed += 5;
                MainWeaponCaliber -= 40;
            }

            else
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (SonarMode)
            {
                sb.AppendLine(" *Sonar mode: ON");
            }

            else
            {
                sb.AppendLine(" *Sonar mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
