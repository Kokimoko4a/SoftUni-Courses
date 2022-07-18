using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> studentsAndPoints = new SortedDictionary<string, Dictionary<string, int>>();
            //  List<int> totalPoints = new List<int>();
            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] arguments = command.Split(":");
                string nameOfContest = arguments[0];
                string password = arguments[1];

                if (!contests.ContainsKey(nameOfContest))
                {
                    contests.Add(nameOfContest, password);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "end of submissions")
            {
                string[] arguments = command.Split("=>");
                string nameOfContest = arguments[0];
                string password = arguments[1];
                string nameOfStudent = arguments[2];
                int points = int.Parse(arguments[3]);

                if (contests.Any(word => word.Value == password))
                {
                    if (!studentsAndPoints.ContainsKey(nameOfStudent))
                    {
                        studentsAndPoints.Add(nameOfStudent, new Dictionary<string, int>());
                        studentsAndPoints[nameOfStudent][nameOfContest] = points;
                    }

                    else if (!studentsAndPoints[nameOfStudent].ContainsKey(nameOfContest))
                    {
                        studentsAndPoints[nameOfStudent].Add(nameOfContest, points);
                    }

                    else if (studentsAndPoints[nameOfStudent].ContainsKey(nameOfContest))
                    {
                        if (points > studentsAndPoints[nameOfStudent][nameOfContest])
                        {
                            studentsAndPoints[nameOfStudent][nameOfContest] = points;
                        }
                    }
                }



                command = Console.ReadLine();
            }


            int max = int.MinValue;
            string theBest = "";

            foreach (var student in studentsAndPoints)
            {
                int currTotalPoints = 0;
                string currName = student.Key;

                foreach (var contest in student.Value)
                {
                    currTotalPoints += contest.Value;
                }
                if (currTotalPoints > max)
                {
                    max = currTotalPoints;
                    theBest = currName;
                }
            }

            Console.WriteLine($"Best candidate is {theBest} with total {max} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in studentsAndPoints)
            {
                var ordered = student.Value.OrderByDescending(x => x.Value);
                Console.WriteLine(student.Key);

                foreach (var result in ordered)
                {
                    Console.WriteLine($"#  {result.Key} -> {result.Value}");
                }
            }

            /*   foreach (var student in studentsAndPoints)
               {
                   Console.WriteLine($"{student.Key}");

                   Console.WriteLine(String.Join("\n", student.Value.OrderByDescending(x => x.Value).Select(y => $"# {y.Key} {y.Value}")));
               }*/
        }
    }
}
