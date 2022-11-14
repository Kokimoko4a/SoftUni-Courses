using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes = new HeroRepository();
        private WeaponRepository wepons = new WeaponRepository();

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.Models.FirstOrDefault(x => x.Name == heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (wepons.Models.FirstOrDefault(x => x.Name == weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            var hero = heroes.FindByName(heroName);

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            var currWeapon = wepons.FindByName(weaponName);

            hero.AddWeapon(currWeapon);
            return $"Hero {heroName} can participate in battle using a {currWeapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            Hero currHero = null;

            if (heroes.Models.FirstOrDefault(x => x.Name == name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type == "Barbarian")
            {
                currHero = new Barbarian(name, health, armour);
            }

            else if (type == "Knight")
            {
                currHero = new Knight(name, health, armour);
            }

            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            /*o	For a knight print: "Successfully added Sir { name } to the collection."
o	For a barbarian print: "Successfully added Barbarian { name } to the collection."
*/

            heroes.Add(currHero);

            if (currHero is Knight)
            {
                return $"Successfully added Sir {name} to the collection.";
            }

            return $"Successfully added Barbarian {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (wepons.Models.FirstOrDefault(x => x.Name == name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            Weapon currWeapon = null;

            if (type == "Mace")
            {
                currWeapon = new Mace(name, durability);
            }

            else if (type == "Claymore")
            {
                currWeapon = new Claymore(name, durability);
            }

            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            wepons.Add(currWeapon);
            return $"A {currWeapon.GetType().Name.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            //orfer them by  hero type alphabetically, then by health descending, then by hero name alphabetically:

            foreach (var hero in heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                /*"{ hero type }: { hero name }
                 --Health: { hero health }
                --Armour: { hero armour }
                --Weapon: { weapon name }/Unarmed
*/

                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                if (hero.Weapon == null)
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }

                else
                {
                    sb.AppendLine($" --Weapon: {hero.Weapon.Name}");
                }

              
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight((ICollection<IHero>)(heroes.Models));
        }
    }
}
