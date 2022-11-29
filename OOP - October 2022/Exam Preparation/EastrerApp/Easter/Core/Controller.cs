using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies = new BunnyRepository();
        private EggRepository eggs = new EggRepository();

        public string AddBunny(string bunnyType, string bunnyName)
        {
            Bunny bunny;

            if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }

            else if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);

            if (bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            Bunny bunny = (Bunny)bunnies.FindByName(bunnyName);
            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            Egg egg = (Egg)eggs.FindByName(eggName);
            List<IBunny> suitableBunnies = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x=>x.Energy).ToList();

            if (suitableBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            Workshop workshop = new Workshop();

            for (int i = 0; i < suitableBunnies.Count; i++)
            {

                if (egg.IsDone() == true)
                {
                    break;
                }

                workshop.Color(egg, suitableBunnies[i]);

                if (suitableBunnies[i].Energy == 0)
                {
                    bunnies.Remove(suitableBunnies[i]);
                    suitableBunnies.Remove(suitableBunnies[i]);
                    i--;
                }
            }

            string finalResult = egg.IsDone() == true ? $"Egg {eggName} is done." : $"Egg {eggName} is not done.";

            return finalResult;
            
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();
            /*"{countColoredEggs} eggs are done!"
            "Bunnies info:"
            "Name: {bunnyName1}"
            "Energy: {bunnyEnergy1}"
            "Dyes: {countDyes} not finished"
*/
            sb.AppendLine($"{eggs.Models.Where(x=>x.IsDone() == true).Count()} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(x => x.IsFinished() == false).Count()} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
