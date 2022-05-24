using System;

namespace Rage_of_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int trashedHeadset = 0;
            int trashedMouse = 0;
            int trashedKeyboard = 0;
            int trashedDisplay = 0;

            for (int i = 1; i <= lostGamesCount ; i++)
            {
                if (i%2==0)
                {
                    trashedHeadset++;
                }

                if (i%3==0)
                {
                    trashedMouse++;
                }

                if (i%2==0 && i%3==0)
                {
                    trashedKeyboard++;
                    if (trashedKeyboard % 2 == 0)
                    {
                        trashedDisplay++;
                    }
                }             
            }

            double sum = trashedHeadset *headsetPrice + trashedMouse *mousePrice + keyboardPrice*trashedKeyboard + trashedDisplay * displayPrice ;
            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
