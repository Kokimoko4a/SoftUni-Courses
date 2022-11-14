using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons = new List<IWeapon>();

        public IReadOnlyCollection<IWeapon> Models { get { return weapons.AsReadOnly(); } }


        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            if (weapons.FirstOrDefault(x => x.GetType().Name == name) != null)
            {
                weapons.Remove(weapons.First(x => x.GetType().Name == name));
                return true;
            }

            return false;
        }
    }
}
