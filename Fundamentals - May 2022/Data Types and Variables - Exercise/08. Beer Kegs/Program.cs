using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfKegs = int.Parse(Console.ReadLine());
            double theBest = double.MinValue;
            string theBestModel = "";

            for (int i = 0; i < countOfKegs ; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume>theBest )
                {
                    theBest = volume;
                    theBestModel = model;
                }
            }

            Console.WriteLine(theBestModel );
        }
    }
}
