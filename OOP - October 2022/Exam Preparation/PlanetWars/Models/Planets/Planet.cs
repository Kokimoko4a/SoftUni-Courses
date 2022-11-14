using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {

        private string name;
        private double budget;
        private WeaponRepository weaponRepository = new WeaponRepository();
        private UnitRepository unitRepository = new UnitRepository();

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }

                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }

                budget = value;
            }
        }

        public double MilitaryPower => CalculatePower();

        public IReadOnlyCollection<IMilitaryUnit> Army { get { return unitRepository.Models; } }

        public IReadOnlyCollection<IWeapon> Weapons { get { return weaponRepository.Models; } }


        private double CalculatePower()
        {
            double power = 0;

            foreach (var item in Army)
            {
                power += item.EnduranceLevel;
            }

            foreach (var item in Weapons)
            {
                power += item.DestructionLevel;
            }

            if (Army.Any(x=>x.GetType().Name == "AnonymousImpactUnit"))
            {
                power += power * 0.3;
            }

            if (Weapons.Any(x=>x.GetType().Name == "NuclearWeapon"))
            {
                power += power * 0.45;
            }

            return Math.Round(power,3);
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            unitRepository.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weaponRepository.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            if (Army.Any())
            {
                List<string> strings = new List<string>();

                foreach (var weapon in Army)
                {
                    strings.Add(weapon.GetType().Name);
                }

                sb.AppendLine($"--Forces: {string.Join(", ",strings)}");
            }

            else
            {
                sb.AppendLine("--Forces: No units");
            }

            if (Weapons.Any())
            {
                List<string> strings = new List<string>();

                foreach (var weapon in Weapons)
                {
                    strings.Add(weapon.GetType().Name);
                }

                sb.AppendLine($"--Combat equipment: {string.Join(", ", strings)}");
            }

            else
            {
                sb.AppendLine("--Combat equipment: No weapons");
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
            /*"Planet: {planetName}
             --Budget: {budgetAmount} billion QUID
            --Forces: {militaryUnitName1}, {militaryUnitName2}, {militaryUnitName3} (…) / No units
            --Combat equipment: {weaponName1}, {weaponName2}, {weaponName3} (…) / No weapons
            --Military Power: {militaryPower}"

             */

        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget-amount<0)
            {
                throw new InvalidOperationException("Budget too low!");
            }

            Budget -= amount;

        }

        public void TrainArmy()
        {
            foreach (var unit in unitRepository.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
