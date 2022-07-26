using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternForValidTickets = @"[^,]*.{20}[^,]*";
            Regex regexForValidTickets = new Regex(patternForValidTickets);
            string[] input = Console.ReadLine().Trim ().Split(",", StringSplitOptions.RemoveEmptyEntries);
            string patternForWinnigTickets = @"\w*(?<symbols>\@{6,10}|\#{6,10}|\${6,10}|\^{6,10})\w*\k<symbols>\w*";
            Regex regexForWinningOnes = new Regex(patternForWinnigTickets);

            foreach (var item in input)
            {
                bool isValid = regexForValidTickets.IsMatch(item);
                string item2 = item.Trim();

                if (isValid)
                {
                    bool isWinning = regexForWinningOnes.IsMatch(item);

                    if (isWinning )
                    {
                        Match match = regexForWinningOnes.Match(item);
                        string symbol = match.Groups["symbols"].ToString ();
                        char symbolOnlyOne = symbol[1]; 
                       
                        int countOfAppear = item.Count(x => x == '@' || x == '^' || x == '#' || x == '$' );
                        int money = countOfAppear / 2;

                        if (money < 10)
                        {
                            Console.WriteLine($"ticket \"{item2.Trim ()}\" - {money}{symbolOnlyOne}");
                        }

                        else if (money == 10)
                        {
                            Console.WriteLine($"ticket \"{ item2 }\" - {money }{symbolOnlyOne} Jackpot!");
                        }
                    }

                    else
                    {
                        Console.WriteLine($"ticket \"{item2}\" - no match");
                    }
                }

                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
