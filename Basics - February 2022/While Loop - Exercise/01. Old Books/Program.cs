using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();
            string currentBook = Console.ReadLine();

            int booksCount = 0;
            bool isFound = false;

            while (currentBook != "No More Books")
            {
               

                if (currentBook ==searchedBook )
                {
                    isFound = true;
                    break;
                }
                booksCount++;
                currentBook = Console.ReadLine();
            }

            if (isFound )
            {
                Console.WriteLine($"You checked {booksCount} books and found it.");
            }

            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {booksCount} books.");
            }






        }
    }
}
