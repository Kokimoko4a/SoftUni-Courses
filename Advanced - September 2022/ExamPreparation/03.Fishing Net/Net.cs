using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material,int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
            Count = 0;
        }

        public List<Fish> Fish { get; set; }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count { get; set; }


        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == String.Empty || fish.Length<=0 || fish.Weight<=0)
            {
                return "Invalid fish.";
            }

            if (Count==Capacity)
            {
                return "Fishing net is full.";
            }

            Count++;
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (Fish.Any(x=>x.Weight == weight))
            {
                Fish.Remove(Fish.First(x => x.Weight == weight));
                Count--;
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        { 
            return Fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            double biggest = Fish.Max(x => x.Length);
            return Fish.First(x => x.Length == biggest);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}:");

            foreach (var fish in Fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
