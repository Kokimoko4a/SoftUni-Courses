using ASP.NET_TaskBoard_App.Data;
using ASP.NET_TaskBoard_App.Data.Models;
using ASP.NET_TaskBoard_App.Extensions;
using ASP.NET_TaskBoard_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Task = ASP.NET_TaskBoard_App.Data.Models.Task;

namespace ASP.NET_TaskBoard_App.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TaskController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<BoardSelectViewModel> boards = await dbContext.Boards.Select(b => new BoardSelectViewModel()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToArrayAsync();

            TaskFormModel task = new TaskFormModel()
            {
                AllBoards = boards             
            };

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel formModel)
        {
           /* if (!ModelState.IsValid)
            {

                return View(formModel);
            }*/

            string userId = this.User.GetId();

            Task task = new Task()
            {
                Title = formModel.Title,
                Description = formModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = formModel.BoardId,
                OwnerId = userId,
            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            //var boards = dbContext.Boards;

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(string id)
        {
            TaskDetailModel task = await dbContext.Tasks.Select(t => new TaskDetailModel()
            {
                Description = t.Description,
                Board = t.Board.Name,
                CreatedOn = t.CreatedOn.ToString("f"),
                Title = t.Title,
                Id = t.Id,
                Owner = t.Owner.UserName

            }).FirstAsync(t => t.Id == id);

            return View(task);
        }

        public async Task<IActionResult> Edit(string id)
        {
            string userId = User.GetId();


            IEnumerable<BoardSelectViewModel> boards = await dbContext.Boards.Select(b => new BoardSelectViewModel()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToArrayAsync();

            Task taskFull = await dbContext.Tasks.FindAsync(id);

           

            if (userId != taskFull!.OwnerId)
            {
                return BadRequest();
            }

            TaskFormModel taskFormModel = new TaskFormModel()
            {
                AllBoards = boards,
                Id = taskFull.Id,
                Title = taskFull.Title,
                Description = taskFull.Description,
                BoardId = taskFull.BoardId,
            };

            return View(taskFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TaskFormModel formModel)
        {
            Task task = await dbContext.Tasks.FindAsync(id);
            string userId = User.GetId();

            if (task == null)
            {
                return BadRequest();
            }

            IEnumerable<BoardSelectViewModel> boards = await dbContext.Boards.Select(b => new BoardSelectViewModel()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToArrayAsync();

            if (!boards.Any(b => b.Id == formModel.BoardId))
            {
                return BadRequest();
            }

            Task taskFull = await dbContext.Tasks.FindAsync(id);

            if (userId != taskFull!.OwnerId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                formModel.AllBoards = boards;
                return View(formModel);
            }

            task.Title = formModel.Title;
            task.Description = formModel.Description;
            task.BoardId = formModel.BoardId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(string id)
        {
            Task taskFull = await dbContext.Tasks.FindAsync(id);

            TaskViewModel taskViewModel = new TaskViewModel()
            {
                Id = id,
                Title = taskFull.Title,
                Description = taskFull.Description,
            };

            return View(taskViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskViewModel)
        {
            Task task = await dbContext.Tasks.FindAsync(taskViewModel.Id);

            if (task == null)
            {
                return BadRequest();
            }

            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }
    }
}
