using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> itemsOfPlanet = planet.Items.ToList();
            


            foreach (var astronaut in astronauts)
            {
                if (astronaut.CanBreath)
                {
                    for (int i = 0; i < itemsOfPlanet.Count; i++)
                    {
                        astronaut.Bag.Items.Add(itemsOfPlanet[i]);
                        itemsOfPlanet.Remove(itemsOfPlanet[i]);
                        i--;
                        astronaut.Breath();


                      /*  if (itemsOfPlanet.Count == 0)
                        {
                            break;
                        }*/

                        if (!astronaut.CanBreath)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
