using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            StringBuilder cryptedMessage = new StringBuilder();

            foreach (var item in message )
            {
                char currLetter = (char)(item + 3);

                cryptedMessage.Append(currLetter);
            }

            Console.WriteLine(cryptedMessage);
        }
    }
}
