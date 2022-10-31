using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<Movie>> cinemasInfos = new Dictionary<string, List<Movie>>();

            while (command != "Done")
            {
                string[] arguments = command.Split(new[] { "<=>", " : " }, StringSplitOptions.RemoveEmptyEntries);
                string cinemaName = arguments[0];
                string movieName = arguments[1];
                decimal ticketPrice = decimal.Parse(arguments[2]);

                if (cinemaName.Length > 20 || cinemaName.Contains('-') || cinemaName.Contains('>'))
                {
                    Console.WriteLine("Invalid cinema name");
                    command = Console.ReadLine();
                    continue;
                }

                else if (movieName.Length > 20 || movieName.Contains('-') || movieName.Contains('>'))
                {
                    Console.WriteLine("Invalid movie name");
                    command = Console.ReadLine();
                    continue;
                }

                Movie currMovie = new Movie(movieName, ticketPrice);

                if (!cinemasInfos.ContainsKey(cinemaName))
                {
                    cinemasInfos.Add(cinemaName, new List<Movie>());
                }
                cinemasInfos[cinemaName].Add(currMovie);

                command = Console.ReadLine();
            }

            var orderedCinemas = cinemasInfos.OrderBy(x => x.Key);

            foreach (var cinema in orderedCinemas)
            {
                /*-Arene
                Harry Potter : 20.60*/

                Console.WriteLine($"- {cinema.Key.Trim()}");

                var ordered = cinema.Value.OrderByDescending(x => x.Price);

                foreach (var movie in ordered)
                {
                    string priceAsStr = movie.Price.ToString().Trim();
                    Console.WriteLine($"{movie.MovieName.Trim()} : {priceAsStr:f2}");
                }
            }

        }
    }

    class Movie
    {
        public Movie(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;
        }

        public string MovieName { get; set; }
        public decimal Price { get; set; }

    }
}
