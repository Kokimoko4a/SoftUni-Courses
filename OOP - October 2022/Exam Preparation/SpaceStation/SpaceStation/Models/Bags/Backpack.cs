using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private List<string> strings = new List<string>();

        public Backpack()
        {

        }

        public ICollection<string> Items { get { return strings; } }

    }
}
