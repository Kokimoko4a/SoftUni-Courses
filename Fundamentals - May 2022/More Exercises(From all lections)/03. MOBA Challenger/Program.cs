using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerInfo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> playerTotalPoints = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (command != "Season end")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string sign = arguments[1];

                if (sign == "->")
                {
                    arguments = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string user = arguments[0];
                    string typeOfSkill = arguments[1];
                    int skillPoints = int.Parse(arguments[2]);

                    if (!playerInfo.ContainsKey(user))
                    {
                        playerInfo.Add(user, new Dictionary<string, int>());
                        playerInfo[user].Add(typeOfSkill, skillPoints);

                    }

                    else if (playerInfo.ContainsKey(user) && playerInfo[user].ContainsKey(typeOfSkill))
                    {
                        if (skillPoints > playerInfo[user][typeOfSkill])
                        {
                            playerInfo[user][typeOfSkill] = skillPoints;
                        }
                    }

                    else if (playerInfo.ContainsKey(user) && !playerInfo[user].ContainsKey(typeOfSkill))
                    {
                        playerInfo[user].Add(typeOfSkill, skillPoints);
                    }
                }

                else if (sign == "vs")
                {
                    arguments = command.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    string opponent1 = arguments[0];
                    string opponent2 = arguments[1];

                    if (playerInfo.ContainsKey(opponent2) && playerInfo.ContainsKey(opponent1))
                    {
                        bool isDefeated = false;

                        foreach (var opponent in playerInfo[opponent1])
                        {
                            string currSkill = opponent.Key;

                            if (isDefeated)
                            {
                                break;
                            }

                            foreach (var defender in playerInfo[opponent2])
                            {
                                if (currSkill == defender.Key)
                                {
                                    int pointOfFirstOpponent = opponent.Value;
                                    int pointOfSecondOpponent = defender.Value;

                                    if (pointOfFirstOpponent > pointOfSecondOpponent)
                                    {
                                        isDefeated = true;
                                        playerInfo.Remove(opponent2);
                                        break;
                                    }

                                    else if (pointOfSecondOpponent > pointOfFirstOpponent)
                                    {
                                        isDefeated = true;
                                        playerInfo.Remove(opponent1);
                                        break;
                                    }

                                    else if (pointOfFirstOpponent == pointOfSecondOpponent)
                                    {
                                        isDefeated = true;
                                        break;
                                    }
                                }
                            }

                        }
                    }

                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var user in playerInfo)
            {
                string currPlayer = user.Key;
                int currTotal = 0;

                foreach (var skill in user.Value)
                {
                    currTotal += skill.Value;
                }

                playerTotalPoints.Add(currPlayer, currTotal);

            }

            playerTotalPoints = playerTotalPoints.OrderByDescending(x => x.Value).ThenBy(name => name.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in playerTotalPoints)
            {
                Console.WriteLine($"{user.Key}: {user.Value} skill");

                foreach (var player in playerInfo)
                {
                    if (player.Key == user.Key)
                    {
                        var ordered = player.Value.OrderByDescending(x => x.Value).ThenBy(name => name.Key);
                        Console.WriteLine(String.Join("\n", ordered.Select(currSkill => $"- {currSkill.Key} <::> {currSkill.Value}")));
                        break;
                    }

                }
            }
        }
    }
}
