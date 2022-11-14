using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        List<IWeapon> weapons = new List<IWeapon>();
        public IReadOnlyCollection<IWeapon> Models { get { return weapons.AsReadOnly(); } }

        public void Add(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IWeapon model)
        {
           var weapon = FindByName(model.Name);

            if (weapon==null)
            {
                return false;
            }

            return true;
        }
    }
}
