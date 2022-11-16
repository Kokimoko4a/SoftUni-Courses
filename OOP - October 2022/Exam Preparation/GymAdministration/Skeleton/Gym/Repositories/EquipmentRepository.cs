using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipments = new List<IEquipment>();
        public IReadOnlyCollection<IEquipment> Models { get { return equipments.AsReadOnly(); } }

        public void Add(IEquipment model)
        {
            equipments.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return equipments.FirstOrDefault(x => x.GetType().Name == type); 
        }

        public bool Remove(IEquipment model)
        {
            if (equipments.FirstOrDefault(x=>x.GetType().Name == model.GetType().Name) == null)
            {
                return false;
            }

            equipments.Remove(model);
            return true;
        }
    }
}
