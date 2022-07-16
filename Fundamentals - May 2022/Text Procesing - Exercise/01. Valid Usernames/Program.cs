using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, string> result = Console.ReadLine().Split().ToDictionary(x=>x.Key,x=>x.Value);

            for (int i = 0; i < usernames.Count; i++)
            {
                string currUsername = usernames[i];

                if (currUsername.Length >= 3 && currUsername.Length <= 16)
                {
                    foreach (var charec in currUsername)
                    {
                        if (!(char.IsLetterOrDigit(charec) || charec == '-' || charec == '_'))
                        {
                            usernames.Remove(currUsername);
                            i--;
                            break;
                        }
                    }
                }

                else
                {
                    usernames.Remove(currUsername);
                    i--;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }


    }
}
