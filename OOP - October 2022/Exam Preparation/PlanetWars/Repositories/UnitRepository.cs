using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> militaryUnits = new List<IMilitaryUnit>();

        public IReadOnlyCollection<IMilitaryUnit> Models { get { return militaryUnits; } }

        public void AddItem(IMilitaryUnit model)
        {
            militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return militaryUnits.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            if (militaryUnits.FirstOrDefault(x => x.GetType().Name == name) != null)
            {
                militaryUnits.Remove(militaryUnits.First(x => x.GetType().Name == name));
                return true;
            }

            return false;
        }
    }
}


