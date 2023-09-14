﻿using ASP.NET_TaskBoard_App.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task = ASP.NET_TaskBoard_App.Data.Models.Task;

namespace ASP.NET_TaskBoard_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; } = null!;

        public DbSet<Board> Boards { get; set; } = null!;

        private Board FirstBoard { get; set; } = null!;
        private Board SecondBoard { get; set; } = null!;
        private Board ThirdBoard { get; set; } = null!;

        private Task Task1 { get; set; }
        private Task Task2 { get; set; }
        private Task Task3 { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            SeedBoards();

            builder.Entity<Board>().HasData(FirstBoard, SecondBoard, ThirdBoard);

            SeedTasks();

            builder.Entity<Task>().HasData(Task1, Task2, Task3);

            base.OnModelCreating(builder);
        }

        private void SeedTasks()
        {
            Task1 = new Task()
            {
                Title = "Cook lunch",
                Description = "Make some good skara",
                CreatedOn = DateTime.Now,
                OwnerId = "95f02134-b722-4e6c-8b86-feea5f5bf300",
                BoardId = 1
            };

            Task2 = new Task()
            {
                Title = "Cook dinner",
                Description = "Just kiding, you don't have to make dinner",
                CreatedOn = DateTime.Now,
                OwnerId = "95f02134-b722-4e6c-8b86-feea5f5bf300",
                BoardId = 2
            };

            Task3 = new Task()
            {
                Title = "Go to Gabrovo",
                Description = "Take your fucking son you go to the fucking clinic in Gabrovo city",
                CreatedOn = DateTime.Now,
                OwnerId = "95f02134-b722-4e6c-8b86-feea5f5bf300",
                BoardId = 2
            };
        }

        private void SeedBoards()
        {

            FirstBoard = new Board()
            {
                Id = 1,
                Name = "Finished"
            };

            SecondBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            ThirdBoard = new Board()
            {
                Id = 3,
                Name = "Mama is cooking it"
            };
        }
    }
}