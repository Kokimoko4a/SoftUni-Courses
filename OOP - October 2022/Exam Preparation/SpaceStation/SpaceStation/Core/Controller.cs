using SpaceStation.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Repositories;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Bags.Contracts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts = new AstronautRepository();
        private PlanetRepository planetRepository = new PlanetRepository();
        private int countOfExploredPlanets = 0;

        public string AddAstronaut(string type, string astronautName)
        {

            Astronaut astronaut;

            if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }

            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }

            else if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }

            else          
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);


        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            Planet planet = (Planet)planetRepository.FindByName(planetName);

            IAstronaut[] suitableAstros = astronauts.Models.Where(x => x.Oxygen > 60).ToArray();

            if (suitableAstros.Length == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            Mission mission = new Mission();
            mission.Explore(planet, suitableAstros);
            countOfExploredPlanets++;

            return $"Planet: {planetName} was explored! Exploration finished with {suitableAstros.Where(x => x.Oxygen == 0).ToArray().Length} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countOfExploredPlanets} planets were explored!");


            sb.AppendLine("Astronauts info:");

            foreach (var astro in astronauts.Models)
            {
                // StringBuilder sbAstro = new StringBuilder();

                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");

                if (astro.Bag.Items.Any())
                {
                    sb.AppendLine($"Bag items: {string.Join(", ",astro.Bag.Items)}");
                }

                else
                {
                    sb.AppendLine("Bag items: none");
                }
            }


            /*"{exploredPlanetsCount} planets were explored!
            Astronauts info:
            Name: { astronautName}
            Oxygen: { astronautOxygen}
            Bag items: { bagItem1, bagItem2, …, bagItemn} / none
…
            Name: { astronautName}
            Oxygen: { astronautOxygen}
            Bag items: { bagItem1, bagItem2, …, bagItemn} / none"*/

            return sb.ToString().TrimEnd();

        }

        public string RetireAstronaut(string astronautName)
        {
            if (astronauts.Models.FirstOrDefault(x => x.Name == astronautName) == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronauts.Remove(astronauts.FindByName(astronautName));
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
