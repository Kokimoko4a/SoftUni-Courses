using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (!Lentgh(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ContainsPossibleThings(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!TwoDigitsLaw(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

           else if (Lentgh(password ) && ContainsPossibleThings(password ) && TwoDigitsLaw(password) )
            {
                Console.WriteLine("Password is valid");
            }
           
        }

        private static bool Lentgh(string password)
        {
            return password.Length >= 6 && password.Length <= 10;       
        }

        private static bool ContainsPossibleThings(string password)
        {
            bool contains = true;
            foreach (char item in password)
            {
                if (!char.IsLetterOrDigit(item))
                {
                    contains = false;
                }
            }

            return contains;

        }

        private static bool TwoDigitsLaw(string password)
        {
            int counter = 0;
            foreach (char item in password)
            {
                if ("0123456789".Contains(item))
                {
                    counter++;
                }

            }
            return counter >= 2;
        }
    }
}
