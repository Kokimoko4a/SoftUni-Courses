using System.ComponentModel.DataAnnotations;

namespace ASP.NET_SplitApp.Models
{
    public class TextViewModel
    {
        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string Text { get; set; } = null!;

        public string SplitText { get; set; } = null!;
    }
}
