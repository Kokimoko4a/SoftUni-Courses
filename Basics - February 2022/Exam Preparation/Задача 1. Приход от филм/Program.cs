using System;

namespace Задача_1._Приход_от_филм
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfMovie = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());

            double pricePerDay = ticketPrice * tickets;
            double totalProfit = pricePerDay * days;
            double profitCinema = totalProfit * percent / 100;
            double finalTotal = totalProfit - profitCinema;
            Console.WriteLine($"The profit from the movie {nameOfMovie} is {finalTotal:f2} lv.");

        }
    }
}
