using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();
           // sw.Start();
            int key = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            string pattern = @"@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*!(?<behave>[GN])!";
            Regex regex = new Regex(pattern);

            while (command != "end")
            {
                StringBuilder currKid = new StringBuilder();

                foreach (var charec in command)
                {
                    char letter = (char)(charec - key);
                    currKid.Append(letter);
                }

                bool isValid = regex.IsMatch(currKid.ToString());

                if (isValid)
                {
                    Match match = regex.Match(currKid.ToString());

                    if (match.Groups["behave"].Value == "G")
                    {
                        Console.WriteLine(match.Groups["name"]);
                    }
                }

                command = Console.ReadLine();
            }
           // sw.Stop();
           /// Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
