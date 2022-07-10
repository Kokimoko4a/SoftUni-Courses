using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyNamesAndId = new Dictionary<string, List<string>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(" -> ");
                string companyName = arguments[0];
                string emplyeeId = arguments[1];

                if (!companyNamesAndId.ContainsKey(companyName))
                {
                    companyNamesAndId.Add(companyName, new List<string>());
                }

                if (!companyNamesAndId[companyName].Contains(emplyeeId))
                {
                    companyNamesAndId[companyName].Add(emplyeeId);
                }
            }

            foreach (var company in companyNamesAndId)
            {
                Console.WriteLine(company.Key);

                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
