using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseCode = new Dictionary<string, char>();
            morseCode.Add(".-", 'A');
            morseCode.Add("-...", 'B');
            morseCode.Add("-.-.", 'C');
            morseCode.Add("-..", 'D');
            morseCode.Add(".", 'E');
            morseCode.Add("..-.", 'F');
            morseCode.Add("--.", 'G');
            morseCode.Add("....", 'H');
            morseCode.Add("..", 'I');
            morseCode.Add(".---", 'J');
            morseCode.Add("-.-", 'K');
            morseCode.Add(".-..", 'L');
            morseCode.Add("--", 'M');
            morseCode.Add("-.", 'N');
            morseCode.Add("---", 'O');
            morseCode.Add(".--.", 'P');
            morseCode.Add("--.-", 'Q');
            morseCode.Add(".-.", 'R');
            morseCode.Add("...", 'S');
            morseCode.Add("-", 'T');
            morseCode.Add("..-", 'U');
            morseCode.Add("...-", 'V');
            morseCode.Add(".--", 'W');
            morseCode.Add("-..-", 'X');
            morseCode.Add("-.--", 'Y');
            morseCode.Add("--..", 'Z');
            morseCode.Add("|", ' ');

            string[] coddeMessage = Console.ReadLine().Split();

            foreach (var code in coddeMessage)
            {
                foreach (var morse in morseCode)
                {
                    if (morse.Key == code)
                    {
                        Console.Write(morse.Value);
                    }
                }
            }
        }
    }
}
