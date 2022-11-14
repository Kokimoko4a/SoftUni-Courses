using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets = new List<IPlanet>();

        public IReadOnlyCollection<IPlanet> Models { get { return planets; } }

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            if (planets.FirstOrDefault(x => x.Name == name) != null)
            {
                planets.Remove(planets.First(x => x.Name == name));
                return true;
            }

            return false;
        }
    }
}
