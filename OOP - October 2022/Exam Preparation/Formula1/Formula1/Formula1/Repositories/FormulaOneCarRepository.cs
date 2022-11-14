using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars = new List<IFormulaOneCar>();
        public IReadOnlyCollection<IFormulaOneCar> Models { get { return cars.AsReadOnly(); } }

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return cars.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (cars.FirstOrDefault(x=>x.Model == model.Model) == null)
            {
                return false;
            }

            cars.Remove(model);
            return true;
        }
    }
}
