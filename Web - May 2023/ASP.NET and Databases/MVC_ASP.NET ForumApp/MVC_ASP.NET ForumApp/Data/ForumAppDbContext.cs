using Microsoft.EntityFrameworkCore;
using MVC_ASP.NET_ForumApp.Data.Models;


namespace MVC_ASP.NET_ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {


        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; init; } = null!;

        private Post Post1 { get; set; } = null!;
        private Post Post2 { get; set; } = null!;
        private Post Post3 { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPosts();

            modelBuilder.Entity<Post>().HasData(Post1, Post2, Post3);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedPosts()
        {
            Post1 = new Post()
            {
                Id = 1,
                Title = "Test",
                Content = "Some content"
            };

            Post2 = new Post()
            {
                Id = 2,
                Title = "Test",
                Content = "Some content"
            }; 

            Post3 = new Post()
            {
                Id = 3,
                Title = "Test",
                Content = "Some content"
            };
        }
    }
}
