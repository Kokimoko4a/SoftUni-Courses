using System;

namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };

            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random random = new Random();

            int countOfMessages = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfMessages; i++)
            {
                string phrase = phrases[random.Next(phrases.Length)];
                string currentEvent = events[random.Next(events.Length)];
                string author = authors[random.Next(authors.Length)];
                string city = cities[random.Next(cities.Length)];

                Console.WriteLine($"{phrase}{currentEvent}{author} - {city}.");

            }
        }
    }
}
