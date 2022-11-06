using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
        }

        public override int Power { get { return 80; }}

        public override string CastAbility()
        {
           return $"Druid - {Name} healed for {Power}";
        }
    }
}
