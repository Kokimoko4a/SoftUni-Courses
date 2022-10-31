using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (command != "END")
            {
                string[] arguments = command.Split(";");

                if (arguments[0] == "Team")
                {
                    try
                    {
                        Team team = new Team(arguments[1]);
                        teams.Add(team);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

                else if (arguments[0] == "Add")
                {
                    try
                    {
                        if (teams.FirstOrDefault(x => x.Name == arguments[1]) != null)
                        {
                            Team currTeam = teams.Find(x => x.Name == arguments[1]);
                            Player player = new Player(arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]), int.Parse(arguments[5]), int.Parse(arguments[6]), int.Parse(arguments[7]));
                            currTeam.AddPLayer(player);
                        }

                        else
                        {
                            throw new ArgumentException($"Team {arguments[1]} does not exist.");
                        }
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else if (arguments[0] == "Remove")
                {
                    if (teams.FirstOrDefault(x => x.Name == arguments[1]) != null)
                    {
                        Team currTeam = teams.Find(x => x.Name == arguments[1]);

                        try
                        {
                            currTeam.RemovePlayer(arguments[2]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    else
                    {
                        Console.WriteLine($"Team {arguments[1]} does not exist.");
                    }

                }

                else if (arguments[0] == "Rating")
                {
                    if (teams.FirstOrDefault(x => x.Name == arguments[1]) != null)
                    {
                        Team currTeam = teams.Find(x => x.Name == arguments[1]);


                        Console.WriteLine($"{arguments[1]} - {Math.Round(currTeam.Rating)}");
                    }

                    else
                    {
                        Console.WriteLine($"Team {arguments[1]} does not exist.");
                    }
                }

                command = Console.ReadLine();
            }


        }
    }
}
