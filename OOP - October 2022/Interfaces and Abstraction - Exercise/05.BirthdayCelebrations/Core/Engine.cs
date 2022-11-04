using _05.BirthdayCelebrations.Core.Interfaces;
using _05.BirthdayCelebrations.IO;
using _05.BirthdayCelebrations.IO.Interfaces;
using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        IRead reader;
        IWriter writer;
        List<IBirthtable> birthdates = new List<IBirthtable>();

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
        }


        public void Run()
        {
            string command = reader.ReadLine();

            while (command !="End")
            {
                string[] cmdArgs = command.Split();

                if (cmdArgs[0] == "Citizen")
                {
                    Person person = new Person(cmdArgs[1],int.Parse( cmdArgs[2]),cmdArgs[3], cmdArgs[4]);
                    birthdates.Add(person);
                }

                else if (cmdArgs[0] == "Pet")
                {
                    Pet pet = new Pet(cmdArgs[1], cmdArgs[2]);
                    birthdates.Add(pet);
                }

                command = reader.ReadLine();
            }

            string year = reader.ReadLine();

            for (int i = 0; i < birthdates.Count; i++)
            {
                IBirthtable birthdate = birthdates[i];
                string[] currDate = birthdate.Birthdate.Split("/");
                string currYear = currDate[2];

                if (currYear == year)
                {
                    writer.WriteLine(birthdate.Birthdate);
                }
            }
        }
    }
}
