using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(30,MinimumLength = 2)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression("^www\\.[A-Za-z-]+\\.com$")]
        public string Website { get; set; } = null!;

        //May be required
        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();
    }
    /*•	Id – integer, Primary Key
•	Name – text with length [5…20] (required)
•	Address – text with length [2…30] (required)
•	Country – text (required)
•	Website – a string (required). First four characters are "www.", followed by upper and lower letters, digits or '-' and the last three characters are ".com".
•	BoardgamesSellers – collection of type BoardgameSeller
*/
}
