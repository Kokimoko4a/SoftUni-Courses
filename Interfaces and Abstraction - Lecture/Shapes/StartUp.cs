using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           Circle circle = new Circle(5);
            circle.Draw();

            Rectangle rectangle = new Rectangle(3, 4);
            rectangle.Draw();
        }
    }
}
