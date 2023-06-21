using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ASP.NET_TaskBoard_App.Models
{
    public class TaskFormModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Display(Name ="Board")]
        public int BoardId { get; set; }

        public IEnumerable<BoardSelectViewModel>? AllBoards { get; set; }
    }
}
