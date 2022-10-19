using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; set; }

        public int Count { get { return Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            
            return $"Successfully added {drone.Name} to the airfield.";



        }

        public bool RemoveDrone(string name)
        {
            Drone droneToRemove = this.Drones.Find(x => x.Name == name);

            return Drones.Remove(droneToRemove);
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.Drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToFly = this.Drones.Find(d => d.Name == name);
            if (droneToFly != null)
                droneToFly.Available = false;
            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {

            List<Drone> dronesToFly = this.Drones.Where(d => d.Range >= range).ToList();
            foreach (Drone drone in dronesToFly)
                this.FlyDrone(drone.Name);

            return dronesToFly;

        }

        public string Report()
        {
            /*StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}");


            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Available == true)
                {
                    sb.AppendLine(Drones[i].ToString());
                }
            }

            return sb.ToString().TrimEnd();*/

               return $"Drones available at {this.Name}:" +
                Environment.NewLine +
                String.Join(Environment.NewLine, this.Drones.Where(d => d.Available));
        }
    }
}
