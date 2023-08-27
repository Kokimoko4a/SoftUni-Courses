

namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            Ads = new HashSet<Ad>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public ICollection<Ad> Ads { get; set; } = null!;
    }

    /*Category
•	Has Id – a unique integer, Primary Key
•	Has Name – a string with min length 3 and max length 15 (required)
•	Has Ads – a collection of type Ad
*/
}
