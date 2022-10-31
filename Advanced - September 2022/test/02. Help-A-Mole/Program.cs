using _02._Help_A_Mole;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine(a.Age);
            a.Print();

            B b = new B();
            Console.WriteLine(b.Age);
            b.Print();
        }
    }

    class A
    {



        private int age;

        public  virtual int Age
        {
            get { return age; }
            set { age = 0; }
        }

        public virtual void Print()
        {
            Console.WriteLine(Age);
        }

    }

    class B : A    
    {
        public override int Age => 1;

        public override void Print() => Console.WriteLine(Age + " " + "bABA TI");

    }
}

