using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class Gym : IGym
    {

        private string name;
        private List<IEquipment> equipments = new List<IEquipment>();
        private List<IAthlete> athletes = new List<IAthlete>();

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity= capacity;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight { get { return Math.Round(equipments.Sum(x => x.Weight),2); } }

        public ICollection<IEquipment> Equipment { get { return equipments; } }
        public ICollection<IAthlete> Athletes { get { return athletes; } }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count + 1 <= Capacity)
            {
                Athletes.Add(athlete);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var item in Athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            List<string> list = new List<string>();

            foreach (var item in Athletes)
            {
                list.Add(item.FullName);
            }

            sb.AppendLine($"{Name} is a {GetType().Name}:");

            if (Athletes.Count > 0)
            {
                sb.AppendLine($"Athletes: {string.Join(", ", list)}");
            }

            else
            {
                sb.AppendLine("Athletes: No athletes");
            }

            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }



        public bool RemoveAthlete(IAthlete athlete)
        {
            if (Athletes.FirstOrDefault(x => x.FullName == athlete.FullName) == null)
            {
                return false;
            }

            Athletes.Remove(athlete);
            return true;
        }
    }
}
