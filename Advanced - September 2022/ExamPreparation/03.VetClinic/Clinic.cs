using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Pets = new List<Pet>();
        }

        public int Capacity { get; set; }
        public List<Pet> Pets { get; set; }
        public int Count { get { return Pets.Count; } }

        public void Add(Pet pet)
        {
            if (Capacity > Pets.Count)
            {
                Pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (Pets.FirstOrDefault(x => x.Name == name) != null)
            {
                Pets.Remove(Pets.Find(x => x.Name == name));
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            return Pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return Pets.OrderByDescending(x => x.Age).First();
        }

        public string GetStatistics()
        {
            return $"The clinic has the following patients:" + Environment.NewLine +
            string.Join(Environment.NewLine, this.Pets.Select(p => $"Pet {p.Name} with owner: {p.Owner}"));
        }
    }
}
