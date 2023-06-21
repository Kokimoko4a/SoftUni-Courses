using ASP.NET_TaskBoard_App.Data;
using ASP.NET_TaskBoard_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_TaskBoard_App.Controllers
{

    [Authorize]
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BoardController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<BoardViewModel> boards = await dbContext.Boards.Select(b => new BoardViewModel()
            {
                Name = b.Name,
                Tasks = b.Tasks.Select(t => new TaskViewModel()
                {
                    Description = t.Description,
                    Id = t.Id,
                    Owner = t.Owner.UserName,
                    Title = t.Title
                }).ToArray(),
            }).ToArrayAsync();


            string test = User.Identity?.Name;

            return View(boards);
        }

      
    }
}
