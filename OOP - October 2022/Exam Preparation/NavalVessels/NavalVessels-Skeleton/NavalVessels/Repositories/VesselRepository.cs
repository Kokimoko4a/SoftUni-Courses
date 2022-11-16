using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels = new List<IVessel>();
        public IReadOnlyCollection<IVessel> Models { get { return vessels.AsReadOnly(); } }

        public void Add(IVessel model)
        {
           vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
          return vessels.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            if (vessels.FirstOrDefault(x=>x.Name == model.Name) == null)
            {
                return false;
            } 

            vessels.Remove(model);
            return true;
        }
    }
}
