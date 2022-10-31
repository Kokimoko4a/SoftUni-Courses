using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTournaments = int.Parse(Console.ReadLine());
            int starterPoints = int.Parse(Console.ReadLine());
            int sum = 0;
            int starterPoints2 = starterPoints;
            double counterOfWins = 0;
           
            for (int i = 0; i < countOfTournaments ; i++)
            {
                string typeOfTournament = Console.ReadLine();
                
                if (typeOfTournament == "SF")
                {
                    sum =starterPoints + 720;
                        starterPoints  = sum;                
                }

                else if (typeOfTournament == "F")
                {
                    sum =starterPoints + 1200;
                    starterPoints = sum;
                }

                else if (typeOfTournament == "W")
                {
                    sum = starterPoints + 2000;
                    starterPoints = sum;
                    counterOfWins++;
                }
              
            }

            double pointPerTournaments = sum - starterPoints2;
            Console.WriteLine($"Final points: {sum}");
            Console.WriteLine($"Average points: {Math.Floor(pointPerTournaments /countOfTournaments) }");
            Console.WriteLine($"{counterOfWins / countOfTournaments * 100:f2}%");
            
        }
    }
}
