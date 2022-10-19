using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public  class Race
    {
        public Race(string name,string type,int laps,int capacity,int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();

        }

        public int MaxHorsePower { get; set; }
        public int Capacity { get; set; }
        public int Laps { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public List<Car> Participants { get; set; }
        public int Count { get; set; }

        public void Add(Car car)
        {
            if (Participants.All(cr=>cr.LicensePlate != car.LicensePlate))
            {
                if (car.HorsePower<=MaxHorsePower)
                {
                    if (Participants.Count<Capacity)
                    {
                        Participants.Add(car);
                        Count++;
                    }
                }

                
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.Any(c=>c.LicensePlate == licensePlate))
            {
                Participants.Remove(Participants.Find(x => x.LicensePlate == licensePlate));
                Count--;
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            if (Participants.Any(x=>x.LicensePlate == licensePlate))
            {
                return Participants.Find(x => x.LicensePlate == licensePlate);
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
           return Participants.OrderByDescending(x=>x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            return $"Race: {Name} - Type: {Type} (Laps: {Laps}){Environment.NewLine}" +
                string.Join(Environment.NewLine, Participants).TrimEnd();
        }
    }
}
