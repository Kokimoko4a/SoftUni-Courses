using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Racers = new List<Racer>();
        }

        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<Racer> Racers { get; set; }

        public int Count { get { return Racers.Count; } }

        public void Add(Racer Racer)
        {
            if (Capacity>Racers.Count)
            {
                Racers.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            if (Racers.FirstOrDefault(x=>x.Name== name) != null)
            {
                Racers.Remove(Racers.Find(x => x.Name == name));
                return true;
            }
            
            return false;
        }

        public Racer GetOldestRacer()
        {
            return Racers.OrderByDescending(x => x.Age).First();
        }

        public Racer GetRacer(string name)
        { 
            return Racers.Find(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return Racers.OrderByDescending(x => x.Car.Speed).First();
        }

        public string Report()
        {
            return $"Racers participating at {Name}:{Environment.NewLine}" +
                string.Join(Environment.NewLine, Racers);

        }

    }
}
