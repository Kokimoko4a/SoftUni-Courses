using System;

namespace _01.ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double surface = 0;
            double literalSurface = 0;
            double volume = 0;

            try
            {
                Box box = new Box(length, width, height);
                surface = box.SurfaceArea();
                literalSurface = box.LateralSurfaceArea();
                volume = box.Volume();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }


            Console.WriteLine($"Surface Area - {surface:f2}");
            Console.WriteLine($"Lateral Surface Area - {literalSurface:f2}"); 
            Console.WriteLine($"Volume - {volume:f2}"); 

        }
    }
}
