using System;
using System.Collections.Generic;

namespace _03._Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {


           
            List<Article> articles = new List<Article>();
            int numberOfArticles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                Article article = new Article (command [0], command [1], command [2]);
               
                articles.Add(article);


            }

            string nonSense = Console.ReadLine();
            foreach (var article in articles )
            {
                Console.WriteLine(article );
            }

        }

        class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            

            public override string ToString() => $"{Title} - {Content}: {Author}";

        }
    }
}

