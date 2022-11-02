using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public  class Robot : RobotAndMan
    {
        public Robot(string model, string id)
        {
            NameOrModel = model;
            Id = id;
        }

        public string Id { get; set; }
        public string NameOrModel { get; set; }
    }
}
