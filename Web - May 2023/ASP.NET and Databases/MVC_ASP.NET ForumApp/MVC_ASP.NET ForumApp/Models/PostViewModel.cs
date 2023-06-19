using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_ASP.NET_ForumApp.Models
{
    public class PostViewModel
    {



        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(1500,MinimumLength = 30)]
        public string Content { get; set; } = null!;

    }
}
