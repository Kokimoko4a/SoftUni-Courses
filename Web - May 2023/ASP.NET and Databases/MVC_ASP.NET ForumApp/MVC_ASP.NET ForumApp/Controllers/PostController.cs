using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ASP.NET_ForumApp.Data;
using MVC_ASP.NET_ForumApp.Data.Models;
using MVC_ASP.NET_ForumApp.Models;

namespace MVC_ASP.NET_ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext dbContext;

        public PostController(ForumAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> All()
        {
            List<PostViewModel> posts = await dbContext.Posts.Select(post => new PostViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Title
            }).ToListAsync();

            return View(posts);
        }

        public async Task<IActionResult> Add() => View(new PostFormModel());


        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel postForm)
        {



            Post post = new Post()
            {

                Title = postForm.Title,
                Content = postForm.Content
            };

            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            var f = dbContext.Posts.FirstOrDefault(x => x.Id == post.Id);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await dbContext.Posts.FindAsync(id)!;

            return View(new PostFormModel()
            {
                Title = post.Title!,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel newModel)
        {
            Post post = await dbContext.Posts.FindAsync(id)!;

            post.Title = newModel.Title;
            post.Content = newModel.Content;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Post post = await dbContext.Posts.FindAsync(id)!;

            dbContext.Posts.Remove(post!);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }

    }
}
