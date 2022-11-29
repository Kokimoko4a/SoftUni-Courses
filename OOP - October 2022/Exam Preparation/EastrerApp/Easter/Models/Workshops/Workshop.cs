using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            List<IDye> dyes = bunny.Dyes.Where(x => x.IsFinished() == false).ToList();

            if (bunny.Energy>0 && bunny.Dyes.Any(x=>x.IsFinished() == false))
            {
                IDye currDye = dyes[0];

                while (bunny.Energy > 0 && dyes.Any() && egg.IsDone() == false)
                {
                    bunny.Work();
                    egg.GetColored();
                    currDye.Use();

                    if (currDye.IsFinished() == true && dyes.Count >1)
                    {
                        bunny.Dyes.Remove(currDye);
                        dyes.RemoveAt(0);
                        currDye = dyes[0];         
                    }

                    else if (currDye.IsFinished() == true && dyes.Count == 1)
                    {
                        break;
                    }
                }
            }


           
        }
    }
}
