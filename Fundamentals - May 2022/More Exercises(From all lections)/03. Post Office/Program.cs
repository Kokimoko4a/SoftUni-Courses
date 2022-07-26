using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This code works 40/100,but it works (:

            string text = Console.ReadLine();
            // string pattern = @"(?<sep>[\#\$\%\*\&])(?<first>[A-Z]+)\k<sep>|(?<asci>[0-9][0-9]):(?<length>[0-9][0-9])|[A-Z][a-z]+";
            string patternForLetters = @"(?<sep>[\#\$\%\*\&])(?<first>[A-Z]+)\k<sep>\|";
            string patternForNumbers = @"(?<asci>[0-9]+):(?<length>[0-9][0-9])";
            string patternForWords = @"\b(?<words>[A-Z][\w\-]+)\b";

            Regex regexForLetters = new Regex(patternForLetters);
            Regex regexForAsciAndLenght = new Regex(patternForNumbers);
            Regex regexForWords = new Regex(patternForWords);
            Match match = regexForLetters.Match(text);
            string capitalLetters = match.Groups["first"].ToString();

            Dictionary<char, int> lettersInfos = new Dictionary<char, int>();
            MatchCollection ascisAndLenghts = regexForAsciAndLenght.Matches(text);
            MatchCollection words = regexForWords.Matches(text);

            foreach (var item in capitalLetters)
            {
                int itemAsciInt = item;
                string itemAsci = itemAsciInt.ToString();

                foreach (Match asciAndLenght in ascisAndLenghts)
                {
                    string currAsci = asciAndLenght.Groups["asci"].ToString();

                    if (itemAsci == currAsci)
                    {
                        int lenght = int.Parse(asciAndLenght.Groups["length"].ToString());
                        lettersInfos.Add(item, lenght);
                        break;
                    }
                }
            }

            foreach (var item in lettersInfos)
            {

                foreach (Match word in words)
                {
                    string wordAsString = word.ToString();
                    int currLength = word.Length;
                    char currLetter = wordAsString[0];

                    if (currLetter == item .Key )
                    {
                        if (currLength == item .Value +1)
                        {
                            Console.WriteLine(word);
                            break;
                        }
                    }
                }
            }

        }
    }
}
