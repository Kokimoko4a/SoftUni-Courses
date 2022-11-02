using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class SmartPhone : ISmartPhone
    {
        public void Browse(string URL)
        {
            Console.WriteLine($"Browsing: {URL}!");
        }

        public void Call(string number)
        {
             Console.WriteLine($"Calling... {number}");
        }
    }
}
