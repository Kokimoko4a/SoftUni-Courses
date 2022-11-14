using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public Claymore(string name, int durability) : base(name, durability)
        {

        }

        public override int DoDamage()
        {

            


            if (Durability-1 <= 0)
            {
                Durability = 0;
                return 0;
            }

            else
            {
                Durability--;
            }

            return 20;
        }
    }
}
