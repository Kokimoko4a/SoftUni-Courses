using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public  class Man : RobotAndMan
    {
        public Man(string name, int age, string id)
        {
            Age = age;
            NameOrModel = name;
            Id = id;
        }

        public int Age { get; set; }
        public string Id { get; set; }
        public string NameOrModel { get;set; }
    }
}
