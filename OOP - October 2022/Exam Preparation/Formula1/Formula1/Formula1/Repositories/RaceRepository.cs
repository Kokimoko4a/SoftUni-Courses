using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races = new List<IRace>();
        public IReadOnlyCollection<IRace> Models { get { return races.AsReadOnly(); } }

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return races.FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            if (races.FirstOrDefault(x=>x.RaceName == model.RaceName) == null)
            {
                return false;
            }

            races.Remove(model);
            return true;
        }
    }
}
