using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots = new List<IPilot>();
        public IReadOnlyCollection<IPilot> Models { get { return pilots.AsReadOnly(); } }

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return pilots.FirstOrDefault(x => x.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            if (pilots.FirstOrDefault(x=>x.FullName == model.FullName) == null)
            {
                return false;
            }

            pilots.Remove(model);
            return true;
        }
    }
}
