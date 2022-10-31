using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lentgh = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            
            int spaceOfRoom = width * lentgh * hight;

            string input;

            while ((input =Console.ReadLine ()) != "Done")
            {
                int box = int.Parse(input);
                spaceOfRoom -= box;

                if (spaceOfRoom<=0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(spaceOfRoom)} Cubic meters more.");
                    break;
                }             
            }
            if (spaceOfRoom >0)
            {
                Console.WriteLine($"{spaceOfRoom} Cubic meters left.");
            }
        }
    }
}
