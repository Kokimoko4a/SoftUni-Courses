using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations = new List<IDecoration>();

        public IReadOnlyCollection<IDecoration> Models { get { return decorations.AsReadOnly(); } }

        public void Add(IDecoration model)
        {
          decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return decorations.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            if (decorations.FirstOrDefault(x=>x.GetType().Name == model.GetType().Name) == null)
            {
                return false;
            }

            decorations.Remove(model);
            return true;
        }
    }
}
