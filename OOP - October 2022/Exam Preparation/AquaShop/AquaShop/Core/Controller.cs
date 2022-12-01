using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    internal class Controller : IController
    {
        private DecorationRepository decorations = new DecorationRepository();
        private List<Aquarium> aquariums = new List<Aquarium>();

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            Aquarium aquarium;

            if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            else if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            Decoration decoration;

            if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }

            else if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish;
            Aquarium aquarium = aquariums.Find(x => x.Name == aquariumName);

            if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName,fishSpecies,price);
            }

            else if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (aquarium  is SaltwaterAquarium)
            {

                if (fish is FreshwaterFish)
                {
                    return "Water not suitable.";
                }

                else
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
              
            }

            else
            {
                if (fish is SaltwaterFish)
                {
                    return "Water not suitable.";
                }

                else
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
            }

        }

        public string CalculateValue(string aquariumName)
        {
            Aquarium aquarium = aquariums.Find(x => x.Name == aquariumName);

            decimal fishValue = aquarium.Fish.Sum(x => x.Price);
            decimal deocValue = aquarium.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {fishValue + deocValue:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            Aquarium aquarium = aquariums.Find(x => x.Name == aquariumName);

            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorations.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            Aquarium aquarium = aquariums.Find(x => x.Name == aquariumName);
            Decoration decoration = (Decoration)decorations.FindByType(decorationType);
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
