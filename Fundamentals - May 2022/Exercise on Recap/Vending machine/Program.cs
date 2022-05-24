using System;

namespace Vending_machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            double sum = 0;

            while ((command = Console.ReadLine ()) !="Start")
            {
                double coin = double.Parse(command);

                if (coin == 0.1)
                {
                    sum += 0.1;
                }

                else if (coin == 0.2)
                {
                    sum += 0.2;
                }

                else if (coin == 0.5)
                {
                    sum += 0.5;
                }

                else if (coin == 1)
                {
                    sum += 1;
                }

                else if (coin == 2)
                {
                    sum += 2;
                }

                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }

            }

            command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Nuts")
                {
                   
                    if (sum >= 2)
                    {
                        sum -= 2;
                        Console.WriteLine($"Purchased {command.ToLower()}");
                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                else if (command =="Water")
                {
                   
                    if (sum>=0.7)
                    {
                        sum -= 0.7;
                        Console.WriteLine($"Purchased {command.ToLower()}");

                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                else if (command == "Crisps")
                {
                   

                    if (sum>=1.5)
                    {
                        sum -= 1.5;
                        Console.WriteLine($"Purchased {command.ToLower()}");

                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                else if (command == "Soda")
                {
                    
                    if (sum>=0.8)
                    {
                        sum -= 0.8;
                        Console.WriteLine($"Purchased {command.ToLower()}");

                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                else if (command == "Coke")
                {
                  
                    if (sum >= 1)
                    {
                        sum -= 1;
                        Console.WriteLine($"Purchased {command.ToLower()}");

                    }

                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid product");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
