﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal CAKE_PRICE = 5;
        private const double CALORIES = 1000;
        private const double GRAMS = 200;

        public Cake(string name) : base(name, CAKE_PRICE, GRAMS, CALORIES)
        {
        }
    }
}
