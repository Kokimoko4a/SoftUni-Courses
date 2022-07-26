using System;

namespace _05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string articleTitle = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {articleTitle}");
            Console.WriteLine("</h1>");

            string articleContent = Console.ReadLine();
            Console.WriteLine("<article>");
            Console.WriteLine($"    {articleContent}");
            Console.WriteLine("</article>");

            string command = Console.ReadLine();

            while (command != "end of comments")
            {
                string arcticleComment = command;

                Console.WriteLine("<div>");
                Console.WriteLine($"    {arcticleComment}");
                Console.WriteLine("</div>");

                command = Console.ReadLine();
            }
        }
    }
}
