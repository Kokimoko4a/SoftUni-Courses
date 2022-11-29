using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private List<IDye> dyes= new List<IDye>();

        public Bunny(string name, int energy)
        {
            Name  = name;   
            Energy = energy;
        }
        public string Name
        {
            get { return name; } private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value;
            } }

        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes { get { return dyes; }}

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }

        public abstract void Work();
        
    }
}
