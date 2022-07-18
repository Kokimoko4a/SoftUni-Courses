using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userInfo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> userInfo2 = new Dictionary<string, int>();

            string command = Console.ReadLine();

            while (command != "no more time")
            {
                string[] argumnets = command.Split(" -> ");
                string userName = argumnets[0];
                string contestName = argumnets[1];
                int points = int.Parse(argumnets[2]);

                if (!userInfo.ContainsKey(contestName))
                {
                    userInfo.Add(contestName, new Dictionary<string, int>());
                    userInfo[contestName].Add(userName, points);
                }

                else if (userInfo.ContainsKey(contestName) && !userInfo[contestName].ContainsKey(userName))
                {
                    userInfo[contestName].Add(userName, points);
                }

                else if (userInfo.ContainsKey(contestName) && userInfo[contestName].ContainsKey(userName))
                {
                    if (points > userInfo[contestName][userName])
                    {
                        userInfo[contestName][userName] = points;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var user in userInfo)
            {
                var oredredUsers = user.Value.OrderByDescending(x => x.Value).ThenBy(name => name.Key);
                Console.WriteLine($"{user.Key}: {user.Value.Count} participants");
                int i = 1;

                foreach (var contest in oredredUsers)
                {
                    Console.WriteLine($"{i++}. {contest.Key} <::> {contest.Value}");
                }
            }

            foreach (var user in userInfo)
            {
                string currContest = user.Key;
                var currResults = user.Value;
                int currPoints = 0;

                foreach (var person in currResults)
                {
                    string currUser = person.Key;
                    currPoints = person.Value;
                    if (!userInfo2.ContainsKey(currUser))
                    {
                        userInfo2.Add(currUser, currPoints);
                    }

                    else
                    {
                        userInfo2[currUser] += currPoints;
                    }

                }
            }

            userInfo2 = userInfo2.OrderByDescending(x => x.Value).ThenBy(name => name.Key).ToDictionary (x=>x.Key ,x=>x.Value );

            Console.WriteLine("Individual standings:");

            int i2 = 1;

            foreach (var user in userInfo2 )
            {              
                Console.WriteLine($"{i2++}. {user.Key} -> {user.Value}");
            }
        }
    }
}
