using ASP.NET_TaskBoard_App.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = ASP.NET_TaskBoard_App.Data.Models.Task;

namespace ASP.NET_TaskBoard_App.Configuration
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasOne(t=> t.Board).WithMany(b => b.Tasks).HasForeignKey(t => t.BoardId).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Title = "Cook lunch",
                    Description = "Make some good skara",
                    CreatedOn= DateTime.Now,
                    OwnerId = "811beaed-fe62-4575-866a-b7df7c873ab0",
                    BoardId = 1
                },

                new Task()
                {
                    Title = "Cook dinner",
                    Description = "Just kiding, you don't have to make dinner",
                    CreatedOn= DateTime.Now,
                    OwnerId = "f0e85c1e-32e3-4ce0-bd33-1a4f64351456",
                    BoardId = 2
                },

                new Task()
                {
                    Title = "Go to Gabrovo",
                    Description = "Take your fucking son you go to the fucking clinic in Gabrovo city",
                    CreatedOn= DateTime.Now,
                    OwnerId = "811beaed-fe62-4575-866a-b7df7c873ab0",
                    BoardId = 2
                },
            }; 

            return tasks;
        } 
    }
}
