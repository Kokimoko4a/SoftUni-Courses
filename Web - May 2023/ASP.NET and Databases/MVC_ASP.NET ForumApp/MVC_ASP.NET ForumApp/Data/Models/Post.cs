using System.ComponentModel.DataAnnotations;

namespace MVC_ASP.NET_ForumApp.Data.Models
{
    public class Post
    {

        [Key]
        [Required]
        public int  Id { get; init; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(1500)]
        public string Content { get; set; } = null!;
    }
}
