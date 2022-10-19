using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Ski>();
        }

        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<Ski> Data { get; set; }
        public int Count { get; set; }

        public void Add(Ski ski)
        {
            if (Data.Count < Capacity)
            {
                Count++;
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (Data.Any())
            {
                if (Data.Any(s=>s.Manufacturer == manufacturer))
                {
                    if (Data.Any(s=>s.Model == model))
                    {
                       Data.Remove(Data.Find(x => x.Manufacturer == manufacturer && x.Model == model));
                        Count--;
                        return true;
                    }                
                }
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            return Data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {   
            return Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            return $"The skis stored in {Name}:{Environment.NewLine}" +
                string.Join(Environment.NewLine, Data);
        }
    }
}
