namespace SoftUniBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ad
    {
        public Ad()
        {
            CreatedOn= DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(250, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        [Required]
        public IdentityUser Owner { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;
    }

    /*•	Has Id – a unique integer, Primary Key
•	Has Name – a string with min length 5 and max length 25 (required)
•	Has Description – a string with min length 15 and max length 250 (required)
•	Has Price – a decimal (required)
•	Has OwnerId – a string (required)
•	Has Owner – an IdentityUser (required)
•	Has ImageUrl – a string (required)
•	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
•	Has CategoryId – an integer, foreign key (required)
•	Has Category – a Category (required)
*/
}
