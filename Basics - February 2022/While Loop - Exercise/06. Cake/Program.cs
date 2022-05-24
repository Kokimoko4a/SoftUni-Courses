using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            int piecesCnt = length * width;

            string command;
            while ((command =Console.ReadLine ()) != "STOP")
            {
                int piecesTaken = int.Parse(command);
                piecesCnt -= piecesTaken;

                if (piecesCnt <0)
                {
                    break;
                }
            }

            if (piecesCnt <0)
            {
                int morePiecesNeeded = Math.Abs(piecesCnt);
                Console.WriteLine($"No more cake left! You need {morePiecesNeeded} pieces more.");
            }

            else
            {             
                Console.WriteLine($"{piecesCnt} pieces are left.");
            }
        }
    }
}
