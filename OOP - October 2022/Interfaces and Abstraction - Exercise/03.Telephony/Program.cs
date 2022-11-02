using System;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in numbers)
            {
                bool isValid = true;

                for (int i = 0; i < item.Length; i++)
                {
                    if (char.IsLetter(item[i]))
                    {
                        Console.WriteLine("Invalid number!");
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    if (item.Length == 10)
                    {
                        SmartPhone smartPhone = new SmartPhone();
                        smartPhone.Call(item);
                    }

                    else if (item.Length == 7)
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();
                        stationaryPhone.Dial(item);
                    }

                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
            }

            string[] URLs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);



            foreach (var item in URLs)
            {
                bool isValid = true;

                for (int i = 0; i < item.Length; i++)
                {
                    if (char.IsDigit(item[i]))
                    {
                        Console.WriteLine("Invalid URL!");
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                   SmartPhone phone = new SmartPhone();
                    phone.Browse(item);
                }
            }
        }
    }
}
