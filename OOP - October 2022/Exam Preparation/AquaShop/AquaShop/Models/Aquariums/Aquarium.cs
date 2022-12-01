using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        public Aquarium(string name, int capacity)
        {
            Name= name;
            Capacity = capacity;
            Decorations = new Collection<IDecoration>();
            Fish = new Collection<IFish>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort { get { return Decorations.Sum(x => x.Comfort); } }

        public ICollection<IDecoration> Decorations { get;  }
        

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count < Capacity)
            {
                Fish.Add(fish);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var item in Fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            /*"{aquariumName} ({aquariumType}):
            Fish: {fishName1}, {fishName2}, {fishName3} (…) / none
            Decorations: {decorationsCount}
            Comfort: {aquariumComfort}"
  */
            sb.AppendLine($"{Name} ({this.GetType().Name}):");

            string result = Fish.Any() ? $"Fish: {string.Join(", ", Fish.Select(x=>x.Name))}" : "Fish: none";
            sb.AppendLine(result);
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            if (Fish.FirstOrDefault(x => x.Name == fish.Name) == null)
            {
                return false;
            }

            Fish.Remove(fish);
            return true;
        }
    }
}
