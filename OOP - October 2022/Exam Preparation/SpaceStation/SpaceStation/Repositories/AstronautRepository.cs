using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts = new List<IAstronaut>();

        public IReadOnlyCollection<IAstronaut> Models { get { return astronauts.AsReadOnly(); } }

        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
           return astronauts.FirstOrDefault(x=>x.Name == name);   
        }

        public bool Remove(IAstronaut model)
        {
            if (astronauts.FirstOrDefault(x => x.Name == model.Name) == null)
            {
                return false;
            }

            astronauts.Remove(astronauts.Find(x => x.Name == model.Name));
            return true;
        }
    }
}
