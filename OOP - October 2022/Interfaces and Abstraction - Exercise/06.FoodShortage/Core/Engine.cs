using _06.FoodShortage.Core.Interfaces;
using _06.FoodShortage.IO;
using _06.FoodShortage.IO.InterFaces;
using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.FoodShortage.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;
        List<IByuer> buyers = new List<IByuer>();

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
        }

        public void Run()
        {
            int countOfPeople = int.Parse(reader.ReadLine());
            int totalAmountOfFood = 0;

            for (int i = 0; i < countOfPeople; i++)
            {
                string[] cmdargs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdargs.Length == 4)
                {
                    Citizen citizen = new Citizen(cmdargs[0], int.Parse(cmdargs[1]), cmdargs[2], cmdargs[3]);
                    buyers.Add(citizen);
                }

                else
                {
                    Rebel rebel = new Rebel(cmdargs[0], int.Parse(cmdargs[1]), cmdargs[2]);
                    buyers.Add(rebel);
                }
            }

            string command = reader.ReadLine();

            while (command != "End")
            {
                if (buyers.FirstOrDefault(x => x.Name == command) != null)
                {
                    var currBuyer = buyers.Find(x => x.Name == command);
                    totalAmountOfFood += currBuyer.BuyFood();

                }

                command = reader.ReadLine();
            }

            Console.WriteLine(totalAmountOfFood);
        }
    }
}
