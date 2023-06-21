using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_TaskBoard_App.Data.Models
{
    public class Task
    {
        public Task()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [System.ComponentModel.DataAnnotations.Required]
        public string Id { get; set; } = null!;

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(10000)]
        public string Description { get; set; } = null!;

        
        public DateTime CreatedOn { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public virtual IdentityUser Owner { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        [System.ComponentModel.DataAnnotations.Required]
        public virtual Board Board { get; set; } = null!;

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }
    }
}
