using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
           string command;
            int steps;

            while ((command= Console.ReadLine()) != "Going home")
            {
                steps = int.Parse(command);
                sum += steps;

                if (sum>10000)
                {
                    Console.WriteLine($"Goal reached! Good job!");
                    Console.WriteLine($"{sum-10000} steps over the goal!");
                    return;
                }
            }

            int stepsToHome = int.Parse(Console.ReadLine());
            if (stepsToHome +sum >=10000)
            {
                Console.WriteLine($"Goal reached! Good job! ");
                Console.WriteLine($"{(sum + stepsToHome) - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000-(sum+stepsToHome)} more steps to reach goal.");
            }
           
        }
    }
}
