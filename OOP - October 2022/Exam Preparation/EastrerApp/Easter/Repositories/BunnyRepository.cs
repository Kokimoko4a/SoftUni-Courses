using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {

        private List<Bunny> bunnies = new List<Bunny>();
        public IReadOnlyCollection<IBunny> Models { get { return bunnies.AsReadOnly(); } }

        public void Add(IBunny model)
        {
            bunnies.Add((Bunny)model);
        }


        public IBunny FindByName(string name)
        {
            return bunnies.FirstOrDefault(b => b.Name == name);
        }

        public bool Remove(IBunny model)
        {
            IBunny bunny = (IBunny)model;

            if (bunnies.FirstOrDefault(x=>x.Name == bunny.Name) == null)
            {
                return false;
            }

            bunnies.Remove((Bunny)bunny);
            return true;
        }

   
    }
}
