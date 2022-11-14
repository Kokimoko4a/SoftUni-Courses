using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilots = new PilotRepository();
        private FormulaOneCarRepository cars = new FormulaOneCarRepository();
        private RaceRepository races = new RaceRepository();

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilots.Models.FirstOrDefault(x => x.FullName == pilotName) == null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            var currPilot = pilots.Models.FirstOrDefault(x => x.FullName == pilotName);

            if (currPilot.CanRace)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }


            if (cars.Models.FirstOrDefault(x => x.Model == carModel) == null )
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");     
            }

            var currCar = cars.Models.FirstOrDefault(x => x.Model == carModel);
            cars.Remove(currCar);
            currPilot.AddCar(currCar);
            return $"Pilot {pilotName} will drive a {currCar.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (races.Models.FirstOrDefault(x => x.RaceName == raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            var currRace = races.Models.FirstOrDefault(x => x.RaceName == raceName);

            /*•	If the pilot does not exist, or the pilot can not race, or the pilot is already in the race, */

            if (pilots.Models.FirstOrDefault(x => x.FullName == pilotFullName) == null)
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            var currPilot = pilots.FindByName(pilotFullName);

            if (currPilot.CanRace == false)
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            if (currRace.Pilots.FirstOrDefault(x => x.FullName == pilotFullName) != null)
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }


            currRace.AddPilot(currPilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";

        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (cars.Models.FirstOrDefault(x => x.Model == model) != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            FormulaOneCar currCar = null;

            if (type == "Williams")
            {
                currCar = new Williams(model, horsepower, engineDisplacement);
            }

            else if (type == "Ferrari")
            {
                currCar = new Ferrari(model, horsepower, engineDisplacement);
            }

            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            cars.Add(currCar);
            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilots.Models.FirstOrDefault(x => x.FullName == fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            var currPilot = new Pilot(fullName);

            pilots.Add(currPilot);
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (races.Models.FirstOrDefault(x => x.RaceName == raceName) != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            Race race = new Race(raceName, numberOfLaps);

            races.Add(race);
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            /*ordered by the number of wins descending. */

            foreach (var racer in pilots.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in races.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (races.Models.FirstOrDefault(x => x.RaceName == raceName) == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            var currRace = races.Models.First(x => x.RaceName == raceName);

            if (currRace.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (currRace.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }


            /*sort all riders in descending order by the result of the RaceScoreCalculator method in FormulaOneCar */

            currRace.TookPlace = true;

            var winner = currRace.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(currRace.NumberOfLaps)).First();
            winner.WinRace();
            Pilot secondPlace = null;
            Pilot thirdPlace = null;


            foreach (var rider in currRace.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(currRace.NumberOfLaps)).Skip(1).Take(1))
            {
                secondPlace = (Pilot)rider;
            }

            foreach (var item in currRace.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(currRace.NumberOfLaps)).Skip(2).Take(1))
            {
                thirdPlace = (Pilot)item;
            }

            /*"Pilot { pilot full name } wins the { race name } race.
            Pilot { pilot full name } is second in the { race name } race.
            Pilot { pilot full name } is third in the { race name } race."
*/

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pilot {winner.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {secondPlace.FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {thirdPlace.FullName} is third in the {raceName} race.");

            return sb.ToString().TrimEnd();

        }
    }
}
