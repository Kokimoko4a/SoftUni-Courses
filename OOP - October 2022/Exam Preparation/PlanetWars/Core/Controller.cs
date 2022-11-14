using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets = new PlanetRepository();

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planets.Models.FirstOrDefault(x => x.Name == planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            var planet = planets.Models.First(x => x.Name == planetName);

            MilitaryUnit militaryUnit = null;

            if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }

            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }

            else if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }

            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            

            if (planet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName) != null)
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";


        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planets.Models.FirstOrDefault(x => x.Name == planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            var planet = planets.Models.First(x => x.Name == planetName);



            if (planet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            Weapon weapon = null;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }

            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }

            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
           

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.FirstOrDefault(x=>x.Name == name) ==null)
            {
                Planet planet = new Planet(name, budget);
                planets.AddItem(planet);
                return $"Successfully added Planet: {name}";
            }

            return $"Planet {name} is already added!";
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x=>x.MilitaryPower).ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.Models.First(x=>x.Name == planetOne); 
            var secondPlanet = planets.Models.First(x=>x.Name == planetTwo);
            double leftOver = 0;
            double weaponsCosts = 0;
            double forcesCosts = 0;

            if (firstPlanet.MilitaryPower== secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.FirstOrDefault(x=>x.GetType().Name == "NuclearWeapon") != null && secondPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }

                else if (firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
                {
                     leftOver = secondPlanet.Budget / 2;
                    firstPlanet.Spend(firstPlanet.Budget/2);
                    firstPlanet.Profit(leftOver);

                     weaponsCosts = 0;
                     forcesCosts = 0;

                    foreach (var item in secondPlanet.Weapons)
                    {
                        weaponsCosts += item.Price;
                    }

                    foreach (var item in secondPlanet.Army)
                    {
                        forcesCosts += item.Cost;
                    }

                    firstPlanet.Profit(forcesCosts + weaponsCosts);

                    planets.RemoveItem(planetTwo);

                    return $"{planetOne} destructed {planetTwo}!";
                }

                else if (secondPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
                {
                     leftOver = firstPlanet.Budget / 2;
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(leftOver);

                     weaponsCosts = 0;
                     forcesCosts = 0;

                    foreach (var item in firstPlanet.Weapons)
                    {
                        weaponsCosts += item.Price;
                    }

                    foreach (var item in firstPlanet.Army)
                    {
                        forcesCosts += item.Cost;
                    }

                    secondPlanet.Profit(forcesCosts + weaponsCosts);

                    planets.RemoveItem(planetOne);

                    return $"{planetTwo} destructed {planetOne}!";
                }

                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
            }

            else if (firstPlanet.MilitaryPower>secondPlanet.MilitaryPower)
            {

                 leftOver = secondPlanet.Budget / 2;
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(leftOver);

                 weaponsCosts = 0;
                 forcesCosts = 0;

                foreach (var item in secondPlanet.Weapons)
                {
                    weaponsCosts += item.Price;
                }

                foreach (var item in secondPlanet.Army)
                {
                    forcesCosts += item.Cost;
                }

                firstPlanet.Profit(forcesCosts + weaponsCosts);

                planets.RemoveItem(planetTwo);

                return $"{planetOne} destructed {planetTwo}!";
            }

                 leftOver = firstPlanet.Budget / 2;
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(leftOver);

                 weaponsCosts = 0;
                 forcesCosts = 0;

                foreach (var item in firstPlanet.Weapons)
                {
                    weaponsCosts += item.Price;
                }

                foreach (var item in firstPlanet.Army)
                {
                    forcesCosts += item.Cost;
                }

                secondPlanet.Profit(forcesCosts + weaponsCosts);

                planets.RemoveItem(planetOne);

                return $"{planetTwo} destructed {planetOne}!";
            
        }

        public string SpecializeForces(string planetName)
        {
            if (planets.Models.FirstOrDefault(x => x.Name == planetName) == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            var planet = planets.Models.First(x => x.Name == planetName);

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            return $"{planetName} has upgraded its forces!";
        }
    }
}
