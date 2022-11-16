using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        protected double defaultArmorThickness;
        private List<string> targets = new List<string>();

        public Vessel(string name, double mainWeaponCaliber, double speed,double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            defaultArmorThickness = armorThickness;
            ArmorThickness = defaultArmorThickness;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainName);
                }

                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get { return targets.AsReadOnly(); } }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);
        }

        public void RepairVessel()
        {     
                ArmorThickness = defaultArmorThickness;         
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            /*"- {vessel name}
 *Type: {vessel type name}
 *Armor thickness: {vessel armor thickness points}
 *Main weapon caliber: {vessel main weapon caliber points}
 *Speed: {vessel speed points} knots
 *Targets: " – if there are no targets "None" Otherwise print "{target1}, {target2}, {target3}, {targetN}"
*/


            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");

            if (targets.Any())
            {
                sb.AppendLine($" *Targets: {string.Join(", ", targets)}");
            }

            else
            {
                sb.AppendLine(" *Targets: None");
            }
     

            return sb.ToString().TrimEnd();
        }
    }
}
