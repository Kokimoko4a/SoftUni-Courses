using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipments = new EquipmentRepository();
        private List<IGym> gyms = new List<IGym>();

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            Athlete athlete = null;

            if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            else if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (athlete is Boxer)
            {
                if (gym.GetType().Name == "BoxingGym")
                {
                    gym.AddAthlete(athlete);
                    return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                }

                else
                {
                    return string.Format(OutputMessages.InappropriateGym);
                }
            }

            else
            {
                if (gym.GetType().Name == "WeightliftingGym")
                {
                    gym.AddAthlete(athlete);
                    return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                }

                else
                {
                    return string.Format(OutputMessages.InappropriateGym);
                }
            }
        }

        public string AddEquipment(string equipmentType)
        {
            Equipment equipment = null;

            if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }

            else if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipments.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }

            else if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            //o	The value should be formatted to the 2nd decimal place!
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (equipments.FindByType(equipmentType) == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            IGym gym = gyms.First(x => x.Name == gymName);
            Equipment equipment = (Equipment)equipments.FindByType(equipmentType);
            gym.AddEquipment(equipment);
            equipments.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder stringBuilder= new StringBuilder();

            foreach (var item in gyms)
            {
                stringBuilder.AppendLine(item.GymInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
