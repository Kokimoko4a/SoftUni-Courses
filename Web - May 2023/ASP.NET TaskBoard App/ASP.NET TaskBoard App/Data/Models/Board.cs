using System.ComponentModel.DataAnnotations;

namespace ASP.NET_TaskBoard_App.Data.Models
{
    public class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual ICollection<Task> Tasks { get; set; } = null!;
    }
}
