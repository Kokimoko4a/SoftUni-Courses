using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models.Interfaces
{
    public interface IByuer
    {
        int BuyFood();

        public int Food { get; }

        public string Name { get;  }

        public int Age { get; }
    }
}
