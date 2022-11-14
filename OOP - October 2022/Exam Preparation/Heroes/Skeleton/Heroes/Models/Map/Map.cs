using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {

            List<Hero> barbarians = new List<Hero>();
            List<Hero> knights = new List<Hero>();
            bool continueBattle = true;

            foreach (var player in players)
            {
                if (player.IsAlive && player.Weapon != null)
                {

                    if (player is Knight)
                    {
                        knights.Add((Hero)player);
                    }

                    else
                    {
                        barbarians.Add((Hero)player);
                    }
                }
            }

            while (continueBattle)
            {
                bool allKnightsDead = true;
                bool allBarbariansDead = true;
                int deadBarbarians = 0;
                int deadKnights = 0;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsDead = false;

                        foreach (var barb in barbarians.Where(x=>x.IsAlive))
                        {
                            barb.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (var barb in barbarians)
                {
                    if (barb.IsAlive)
                    {
                        allBarbariansDead = false;

                        foreach (var knight in knights.Where(x=>x.IsAlive == true))
                        {
                            knight.TakeDamage(barb.Weapon.DoDamage());
                        }
                    }
                }

                if (allKnightsDead)
                {
                    return $"The barbarians took {barbarians.Where(x => x.IsAlive == false).Count()} casualties but won the battle.";
                }

                else if (allBarbariansDead)
                {
                    return $"The knights took {knights.Where(x => x.IsAlive == false).Count()} casualties but won the battle.";
                }
            }

            throw new InvalidOperationException();
        }

    }
}

