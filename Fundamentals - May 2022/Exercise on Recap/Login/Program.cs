using System;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            int count = 0;

            for (int i = username.Length -1; i >= 0; i--)
            {
                password += username[i];
            }

            string opit = "";


            while ((opit = Console.ReadLine ()) != password)
            {
                
                count++;

                if (count ==4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
            }


            if (opit == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
