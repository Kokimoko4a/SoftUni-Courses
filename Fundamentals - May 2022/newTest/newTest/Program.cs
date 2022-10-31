using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace newTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Turtle t = new Turtle("Greta");
            Console.WriteLine(t.Name); 
        }
    }

    class Animal
    {

        public Animal(string name)
        {
            Name = name;
        }

        public  virtual string Name { get; set; }




    }

    class Turtle : Animal
    {
        public Turtle(string name) : base(name)
        {
            Name = name;
        }

        public override string Name { get; set; }
    }
}


