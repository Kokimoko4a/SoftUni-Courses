using _05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations.Models
{
    public class Pet : IBirthtable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }

        
    }
}
