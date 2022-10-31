using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer()
        {
            Pokemons = new List<Pokemon>();
        }

        public List<Pokemon> Pokemons { get; set; }
        public int NumberOfBadges { get; set; }
        public string  Name  { get; set; }
    }
}
