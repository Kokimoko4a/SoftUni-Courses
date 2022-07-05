using System;
using System.Collections.Generic;

namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] currArticle = Console.ReadLine().Split(", ");
            Article article = new Article(currArticle[0], currArticle[1], currArticle[2]);
            int countOfchanges = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfchanges ; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string action = command[0];
                string newThing = command[1];

                if (action == "Edit")
                {
                    article.Edit(newThing);
                }

                else if (action == "ChangeAuthor")
                {
                    article.ChangeAuthor(newThing);
                }

                else if (action == "Rename")
                {
                    article.Rename(newThing);
                }
            }

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

        public void Edit(string newThing)
        {
            Content = newThing;

        }

        public void ChangeAuthor(string newThing)
        {
            Author = newThing;
           
        }

        public void Rename(string newThing)
        {
            Title = newThing;

        }

        public override string ToString() => $"{Title} - {Content}: {Author}";

    }
}
