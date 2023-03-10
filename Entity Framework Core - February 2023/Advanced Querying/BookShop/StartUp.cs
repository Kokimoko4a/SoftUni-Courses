namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Collections.Immutable;
    using System.Globalization;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);

            // string input = Console.ReadLine()!;

            //int inputNumber = int.Parse(Console.ReadLine()!);


            Console.WriteLine(RemoveBooks(context)); 
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var titles = context.Books.Where(x => x.AgeRestriction == ageRestriction).Select(x => x.Title).OrderBy(x => x).ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books.Where(et => et.EditionType == EditionType.Gold && et.Copies < 5000).OrderBy(b => b.BookId).Select(b => b.Title).ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var titles = context.Books.Where(b => b.Price > 40).OrderByDescending(b => b.Price).Select(b => new { b.Title, b.Price }).ToArray();

            return string.Join(Environment.NewLine, titles.Select(b => $"{b.Title} - ${b.Price:f2}")).TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context.Books.Where(b => b.ReleaseDate!.Value.Year != year).OrderBy(b => b.BookId).Select(t => t.Title).ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();

            var titles = context.Books.Where(bc => bc.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .OrderBy(x => x.Title).Select(x => x.Title).ToArray();

            return string.Join(Environment.NewLine, titles).TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.CurrentCulture);

            var titles = context.Books.Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(x => x.ReleaseDate).Select(x => new { x.Title, x.EditionType, x.Price }).ToArray();

            return string.Join(Environment.NewLine, titles.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}")).TrimEnd();

        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors.Where(a => a.FirstName.EndsWith(input)).Select(a => a.FirstName + " " + a.LastName).OrderBy(x => x).ToArray();

            return string.Join(Environment.NewLine, authors).TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] titles = context.Books.Where(b => b.Title.ToLower().Contains(input.ToLower())).Select(x => x.Title).ToArray();

            return string.Join(Environment.NewLine, titles.OrderBy(x => x)).TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var auhorsAndTitles = context.Books.Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower())).OrderBy(x => x.BookId)
                .Select(x => new
                {
                    AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                    BookTitle = x.Title

                }).ToArray();

            return string.Join(Environment.NewLine, auhorsAndTitles.Select(x => $"{x.BookTitle} ({x.AuthorName})"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books.Count(x => x.Title.Length > lengthCheck);

            return count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var titlesCopies = context.Authors.Select(x => new
            {
                Copies = x.Books.Sum(x => x.Copies),
                Autor = x.FirstName + " " + x.LastName
            }).OrderByDescending(x => x.Copies).ToArray();

            return string.Join(Environment.NewLine, titlesCopies.Select(x => $"{x.Autor} - {x.Copies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesPorfit = context.Categories.Select(x => new
            {
                Category = x.Name,
                Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)

            }).OrderByDescending(x => x.Profit).ThenBy(x => x.Category).ToArray();

            return string.Join(Environment.NewLine, categoriesPorfit.Select(x => $"{x.Category} ${x.Profit:f2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories.Select(x => new
            {
                CategoryName = x.Name,
                Books = x.CategoryBooks.OrderByDescending(x => x.Book.ReleaseDate).Take(3).Select(x => new { x.Book.Title, x.Book.ReleaseDate!.Value.Year }).ToArray()
            }).OrderBy(x => x.CategoryName).ToArray();



            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate!.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            int booksToBeRemovedCount = context.Books.Count(b => b.Copies < 4200);

            var booksToRemove = context.Books.Where(b => b.Copies < 4200).ToList();
         
            var booksCategoriesToRemove = context.BooksCategories.Where(x => x.Book.Copies < 4200).ToArray();

            context.BooksCategories.RemoveRange(booksCategoriesToRemove);

            context.Books.RemoveRange(booksToRemove);

            context.SaveChanges();

            return booksToBeRemovedCount;
        }
    }
}


