using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs = new List<IEgg>();
        public IReadOnlyCollection<IEgg> Models { get { return eggs.AsReadOnly(); } }

        public void Add(IEgg model)
        {
            eggs.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            if (eggs.FirstOrDefault(x => x.Name == model.Name) == null)
            {
                return false;
            }

            eggs.Remove(model);
            return true;
        }
    }
}
