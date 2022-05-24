using System;

namespace _06.Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfMovie;
            int standard = 0;
            int student = 0;
            int kid = 0;
            int countOfFinalTickets = 0;
            int finalStudent = 0;
            int finalKid = 0;
            int finalStandard = 0;

            while ((nameOfMovie = Console.ReadLine()) != "Finish")
            {
                int freePlaces = int.Parse(Console.ReadLine());
                double freePlaces2 = freePlaces;

                while (freePlaces >0)
                {
                    string typeOfTicket = Console.ReadLine();

                    if (typeOfTicket == "standard")
                    {
                        standard++;
                        freePlaces--;
                    }

                    else if (typeOfTicket == "student")
                    {
                        student++;
                        freePlaces--;
                    
                    }

                    else if(typeOfTicket == "kid")
                    {
                        kid++;
                        freePlaces--;
                    }

                    if (typeOfTicket == "End")
                    {
                        break;
                    }                                                                
                }

               int countOfTickets = standard + student + kid ;
                countOfFinalTickets += countOfTickets;
                Console.WriteLine($"{nameOfMovie} - {(countOfTickets/freePlaces2)*100:f2}% full.");
                finalKid += kid;
                finalStandard += standard;
                finalStudent += student;
                student = 0;
                standard = 0;
                kid = 0;                            
            }

            Console.WriteLine($"Total tickets: {countOfFinalTickets}");
            Console.WriteLine($"{(double)finalStudent  /countOfFinalTickets*100:f2}% student tickets.");
            Console.WriteLine($"{(double)finalStandard /countOfFinalTickets*100:f2}% standard tickets.");
            Console.WriteLine($"{(double)finalKid /countOfFinalTickets*100:f2}% kids tickets.");
        }
    }
}
