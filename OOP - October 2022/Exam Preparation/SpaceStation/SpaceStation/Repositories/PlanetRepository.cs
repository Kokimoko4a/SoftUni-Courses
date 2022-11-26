using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    internal class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets= new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models { get { return planets.AsReadOnly(); } }

        public void Add(IPlanet model)
        {
           planets.Add(model);  
        }

        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            if (planets.FirstOrDefault(x => x.Name == model.Name) == null)
            {
                return false;
            }

            planets.Remove(planets.Find(x => x.Name == model.Name));
            return true;
        }
    }
}
